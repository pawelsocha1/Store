
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
        [Required(ErrorMessage = "Wprowadz nazwę produktu")]
        [StringLength(100)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        

        public IEnumerable<Category> Categories { get; set; }
        public virtual Brand Brands { get; set; }

    }
}