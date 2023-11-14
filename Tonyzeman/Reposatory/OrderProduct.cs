using Tonyzeman.Models;
using Tonyzeman.Models.Context;
using Tonyzeman.Repository.IReposatory;

namespace Tonyzeman.Repository
{
    public class OrderProduct : Repository<OrderProduct>, IOrderProduct
    {
        public OrderProduct(TonyzemanContext db) : base(db)
        {
        }
    }
}
