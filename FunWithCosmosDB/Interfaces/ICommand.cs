namespace FunWithCosmosDB.Interfaces
{
    public interface ICommand<TArgs>
    {
        void Execute(TArgs arguments);
    }

    public interface ICommand<TArgs, TResponse>
    {
        TResponse Execute(TArgs arguments);
    }
}
