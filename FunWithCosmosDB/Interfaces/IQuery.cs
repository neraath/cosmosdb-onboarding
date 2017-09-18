namespace FunWithCosmosDB.Interfaces
{
    public interface IQuery<TResponse>
    {
        TResponse Query();
    }

    public interface IQuery<TArgs, TResponse>
    {
        TResponse Query(TArgs args = default(TArgs));
    }
}
