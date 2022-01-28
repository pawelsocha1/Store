using Store.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Store.Models
{
    public class TestMemoryProductRepository
    {
        private Dictionary<int, Product> _products;
        private int index;
        public TestMemoryProductRepository()
        {
            _products = new Dictionary<int, Product>();
        }
        public Product Add(Product book)
        {
            book.Id = nextIndex();
            _products.Add(book.Id, book);
            return book;
        }
        public void Delete(int id)
        {
            _products.Remove(id);
        }
        public ICollection<Product> FindAll()
        {
            return _products.Values;
        }
        private int nextIndex()
        {
            return ++index;
        }
        
    }
}