using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Seeder
    {
        private readonly ApplicationDbContext _dbContext;

        public Seeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
             
                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();


                }
                if (!_dbContext.Brands.Any())
                {
                    var brands = GetBrands();
                    _dbContext.Brands.AddRange(brands);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }
            }
        }




        private IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                   CategoryName="Bluzy"



                },

                new Category()
                {
                   CategoryName="Koszulki"

                },


            };
            return categories; 
                }
        
        private IEnumerable<Brand> GetBrands()
        {
            var brands = new List<Brand>()
            {
                new Brand()
                {
                   BrandName="Nike"



                },

                new Brand()
                {
                   BrandName="adidas"

                },


            };
            return brands;
        }
            private IEnumerable<Product> GetProducts()
            {
            var products = new List<Product>()
                {
                new Product()
                {
                    ProductName = "Bluza Nike",
                    Price = 300,
                  
                },
              

                new Product()
                {
                    ProductName = "Bluza adidas",
                    Price = 350,
             



                },

                new Product()
                {
                    ProductName = "Koszulka Nike",
                    Price = 120,
              
                    Brands=new Brand()
                    {
                        BrandName="Nike"
                    }

                }
            };
                return products;
            }
        }
    }

