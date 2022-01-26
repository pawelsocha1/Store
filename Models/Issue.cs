using Store.Models;

namespace Store.Controllers
{
    public class Issue
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Product Product { get; set; }
    }
}