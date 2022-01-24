using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public interface ICRUDProductRepository
    {
        Product FindById(int id);
        Product Add(Product product);

        void Delete(int id);

        Product Update(Product product);

        List<Product> FindAll();

    }
}
