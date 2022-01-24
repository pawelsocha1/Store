using Microsoft.AspNetCore.Mvc;
using Store.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Product
    {
        [HiddenInput]
        public int Id { get; set; }
        public int Kategoria { get; set; }
        [Required(ErrorMessage = "Wprowadz nazwę produktu")]
        [StringLength(100)]
        public string NazwaProduktu { get; set; }
        [Required(ErrorMessage = "Wprowadz nazwę marki")]
        [StringLength(100)]
        public int Marka { get; set; }
        public string OpisProduktu { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CenaProduktu { get; set; }
        public ICollection<Issue> Issues { get; set; }
    }
}
