using Tonyzeman.Models;
using Tonyzeman.Models.Context;
using Tonyzeman.Repository.IReposatory;

namespace Tonyzeman.Repository
{
    public class ProductRepository : Repository<Product>, IProduct
    {
        private TonyzemanContext db;
        public ProductRepository(TonyzemanContext db) : base(db)
        {
            this.db = db;
        }

        public Product GetByName(string name)
        {
            var product = db.Products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception();
            }
        }

     
    }
}
