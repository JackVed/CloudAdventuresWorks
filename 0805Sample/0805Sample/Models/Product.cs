using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _0805Sample.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public int StandardCost { get; set; }
        public float ListPrice { get; set; }
        public DateTime SellStartDate { get; set; }

        public Product(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Product(string Name, string ProductNumber, int StandardCost, float ListPrice, DateTime SellStartDate)
        {
            this.Name = Name;
            this.ProductNumber = ProductNumber;
            this.StandardCost = StandardCost;
            this.ListPrice = ListPrice;
            this.SellStartDate = SellStartDate;
        }
    }
}
