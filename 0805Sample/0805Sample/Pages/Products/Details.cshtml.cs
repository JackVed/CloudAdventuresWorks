using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0805Sample.Data;
using _0805Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _0805Sample.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public Product List { get; set; }

        private IDataAccess _data;

        public DetailsModel(IDataAccess data)
        {
            this._data = data;
        }

        public void OnGet(int id)
        {
            List = this._data.GetProductsById(id);
        }
    }
}