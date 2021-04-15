using SidmachStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Services
{
    public interface IProduct
    {

        List<Product> GetProduct();

        Product GetProduct(Guid Id);


        Product AddProduct(Product product);


        Product EditProduct(Product product);


        void DeleteProduct(Product product);
    }
}
