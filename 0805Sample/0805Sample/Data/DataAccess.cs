using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using _0805Sample.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace _0805Sample.Data
{  

    public class DataAccess : IDataAccess
    {
        private string _connectionstring;

        public DataAccess(IConfiguration config)
        {
            this._connectionstring = config.GetConnectionString("cs");
        }

        public IEnumerable<Product> GetProducts()
        {
            var querySelect = @"
                                SELECT [ProductID] as Id,
                                [Name]
                                FROM [SalesLT].[Product]";

            using (var connection = new SqlConnection(_connectionstring))
            {
                var products = connection.Query<Product>(querySelect);
                return products;
            }
        }

        public Product GetProductsById(int id)
        {
            var querySelectById = @"
                                    SELECT [ProductID] as Id,
                                    [Name],
                                    [ProductNumber],
                                    [StandardCost],
                                    [ListPrice],
                                    [SellStartDate]
                                    FROM [SalesLT].[Product]
                                    WHERE ProductID = @id";

            using (var connection = new SqlConnection(_connectionstring))
            {
                Product product = connection.QueryFirstOrDefault<Product>(querySelectById, new { id });
                return product;
            }
        }

        public void PostProduct(Product product)
        {
            var queryInsert = @"
                                INSERT INTO [SalesLT].[Product]
                                           ([Name]
                                           ,[ProductNumber]                                           
                                           ,[StandardCost]
                                           ,[ListPrice]
                                           ,[SellStartDate]  )
                                     VALUES
                                           (@Name,
                                           @ProductNumber,                                         
                                           @StandardCost,
                                           @ListPrice,                                           
                                           @SellStartDate)";

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Execute(queryInsert, product);
            }
        }

        //public IEnumerable<Product> GetProducts()
        //{
        //    var temp = new List<Product>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        temp.Add(new Product
        //        {
        //            Id = i,
        //            Name = $"Prodotto {i}"
        //        });
        //    }
        //    return temp;
        //}
    }
}
