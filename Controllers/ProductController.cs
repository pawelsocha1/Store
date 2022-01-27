using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers

{
  
    public class ProductController : Controller
    {
        private ICRUDProductRepository repository;
        private IProductRepository productRepository;

        public ProductController(ICRUDProductRepository repository, IProductRepository productRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
        }

       public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductForm()
        {
            return View();
        }
     
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                return View("ConfirmProduct", repository.Add(product));
            }
            else
            {
                return View("ProductForm");
            }
        }

        public IActionResult List()
        {
            return View(repository.FindAll());
        }
        public IActionResult Issue()
         {
             Issue issue = new Issue()
             {
                 Id = 1

             };
             productRepository.addIssue(4, issue);
             return View("List", repository.FindAll());
         }
    }
}
