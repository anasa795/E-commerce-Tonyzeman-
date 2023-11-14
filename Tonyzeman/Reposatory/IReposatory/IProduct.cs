using Tonyzeman.Models;

namespace Tonyzeman.Repository.IReposatory
{
    public interface IProduct:IReposatory<Product>
    {
        Product GetByName(string name);
    }
}
