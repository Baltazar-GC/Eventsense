namespace Eventsense;
public interface IManyToManyEntity<K1, K2> : IDataEntity
{
    K1 Key1 { get; }

    K2 Key2 { get; }
}