using System.Collections.Generic;

namespace Store.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        public int NazwaKategorii { get; set; }

        public virtual ICollection<Product> Produkty { get; set; }
    }
}