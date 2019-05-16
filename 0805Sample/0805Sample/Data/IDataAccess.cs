using _0805Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0805Sample.Data
{
    public interface IDataAccess
    {
        IEnumerable<Product> GetProducts();
        Product GetProductsById(int id);
        void PostProduct(Product product);
    }
}
