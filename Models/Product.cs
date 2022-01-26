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
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Wprowadz nazwę produktu")]
        [StringLength(100)]
        public string ProductName { get; set; }
        
        public int BrandId { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public ICollection<Issue> Issues { get; set; }

        public virtual Category Categories { get; set; }
        public virtual Brand Brands { get; set; }

    }
}
