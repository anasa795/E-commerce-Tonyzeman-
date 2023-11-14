using Tonyzeman.Models;
using Tonyzeman.Models.Context;
using Tonyzeman.Repository.IReposatory;

namespace Tonyzeman.Repository
{
    public class OrderRepository : Repository<Order>, IOrder
    {
        public OrderRepository(TonyzemanContext db) : base(db)
        {
        }
    }
}
