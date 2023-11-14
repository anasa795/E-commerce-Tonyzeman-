namespace Tonyzeman.Repository.IReposatory
{
    public interface IUnitOfWork
    {
        IProduct Product { get; }
        IOrder Order { get; }
        IOrderProduct OrderProduct { get; }
        ICategory Category { get; }

        void Save();
    }
}
