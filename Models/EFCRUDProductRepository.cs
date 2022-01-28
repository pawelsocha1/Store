using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace Store
{
    public class EFCRUDProductRepository : ICRUDProductRepository
    {
        private ApplicationDbContext context;

        public EFCRUDProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Product Add(Product Product)
        {
            EntityEntry<Product> entityEntry = context.Add(Product);
            context.SaveChanges();
            return entityEntry.Entity;

        }

        public void Delete(int id)
        {
            context.Products.Remove(context.Products.Find(id));
            context.SaveChanges();
        }

        public List<Product> FindAll()
        {
            return context.Products.ToList();
        }

        public Product FindById(int id)
        {
            return context.Products.Find(id);
        }

    
        public Product Update(Product product)
        {
        

        EntityEntry<Product> entityEntry = context.Products.Update(product);
        context.SaveChanges();
        return entityEntry.Entity;
        }
    }
}
