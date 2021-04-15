using Microsoft.EntityFrameworkCore;
using SidmachStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Services
{
    public class SqlProductData : IProduct
    {
        private readonly ProductContext _productContext;

        public SqlProductData(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public Product AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _productContext.Products.Add(product);
            _productContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(Product product)
        {
            _productContext.Products.Remove(product);
            _productContext.SaveChanges();
        }

        public Product EditProduct(Guid id, Product product)
        {
            var existingProduct = _productContext.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                _productContext.Products.Update(existingProduct);
                _productContext.SaveChanges();
            }

            return product;
        }

        public Product EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(Guid id)
        {

            var product = _productContext.Products.Include(p => p.Category).Single(p => p.Id == id);
            return product;
           
        }

        public List<Product> GetProduct()
        {

            return _productContext.Products.Include(p => p.Category).ToList();
        }
    }
}
