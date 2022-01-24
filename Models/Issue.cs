using Store.Models;

namespace Store.Controllers
{
    public class Issue
    {
        public int Id { get; set; }
        public string NazwaProduktu { get; set; }
        public Product Product { get; set; }
    }
}