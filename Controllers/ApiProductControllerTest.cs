using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Store.Controllers
{
    public class ApiProductControllerTest : Controller
    {

        [Fact]
        public void TestGet()
        {
            //Given
            ApiProductController controller = new ApiProductController();
            Product expected = new Product()
            {
                ProductName = "Bluza Nike",
                Size = null,
                Price = 250
                
            };
            //When
            Product actual = controller.GetProduct(1).Value;
            //Then
            Assert.Equal(expected.ProductName, actual.ProductName);
            Assert.Equal(expected.Price, actual.Price);
            Assert.Equal(expected.Size, actual.Size);
        }

    }
}
