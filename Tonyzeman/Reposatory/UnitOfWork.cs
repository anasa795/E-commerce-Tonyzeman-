using Tonyzeman.Models.Context;
using Tonyzeman.Models;
using Tonyzeman.Repository.IReposatory;

namespace Tonyzeman.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private TonyzemanContext db;
        public IProduct Product { get; private set; }
        public IOrder Order { get; private set; }
        public IOrderProduct OrderProduct { get; private set; }
        public ICategory Category { get; private set; }

        public UnitOfWork(TonyzemanContext db)
        {
            this.db = db;
            Product = new ProductRepository(db);
            Category = new CategoryRepository(db);
            Order = new OrderRepository(db);
            OrderProduct = new OrderProduct(db);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
