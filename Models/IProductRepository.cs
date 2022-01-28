using Store.Models;
using System.Linq;

namespace Store.Controllers
{
    public interface IProductRepository
    {
        IQueryable<Product> products { get; }
        
    }
}