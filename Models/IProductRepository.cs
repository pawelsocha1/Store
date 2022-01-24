using Store.Models;
using System.Linq;

namespace Store.Controllers
{
    public interface IProductRepository
    {
        IQueryable<Product> contacts { get; }
        void addIssue(int contactId, Issue issue);
    }
}