using Tonyzeman.Models;
using Tonyzeman.Models.Context;
using Tonyzeman.Repository.IReposatory;

namespace Tonyzeman.Repository
{
    public class CategoryRepository : Repository<Category>, ICategory
    {
        public CategoryRepository(TonyzemanContext db) : base(db)
        {
        }
    }
}
