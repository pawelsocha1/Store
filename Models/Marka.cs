using System.Collections.Generic;

namespace Store.Models
{
    public class Marka
    {
        public int MarkaId { get; set; }
        public int NazwaMarki { get; set; }

        public virtual ICollection<Product> Produkty { get; set; }
    }
}