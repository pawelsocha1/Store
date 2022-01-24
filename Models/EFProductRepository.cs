using Store.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> products => _context.Products;

        public void addIssue(int Id, Issue issue)
        {
            Product product = _context.Products.Find(Id);
            product.Issues.Add(issue);
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}