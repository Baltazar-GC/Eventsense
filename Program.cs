using System.Security.Claims;
using Eventsense;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EventSenseDataContext>(options =>
    {
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        options.UseSqlServer(
            builder.Configuration["ConnectionStrings:DefaultConnection"],
            providerOptions =>
            {
                providerOptions.EnableRetryOnFailure();
                providerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                providerOptions.CommandTimeout(120);
            }
        );
    });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
    options.Audience = builder.Configuration["Auth0:Audience"];
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = ClaimTypes.NameIdentifier
    };
});

builder.Services
    .AddAuthorization(options =>
    {
        options.AddPolicy(
        "read:messages",
        policy => policy.Requirements.Add(
            new HasScopeRequirement("read:messages", builder.Configuration["Auth0:Domain"])
        )
        );
    });
    
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

builder.Services.AddScoped<IGuestsServices, GuestsService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
