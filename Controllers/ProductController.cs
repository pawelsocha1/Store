﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return View("List", repository.FindAll());
        }

        public IActionResult EditForm(int id)
        {
            return View(repository.FindById(id));
        }

        public IActionResult Edit(Product product)
        {
            repository.Update(product);
            return View("List", repository.FindAll());
        }




    }
    }


