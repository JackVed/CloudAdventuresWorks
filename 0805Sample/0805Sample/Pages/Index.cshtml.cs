using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0805Sample.Data;
using _0805Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _0805Sample.Pages
{
    public class IndexModel : PageModel
    {
        public string CurrentDate { get; set; }

        public IEnumerable<Product> List { get; set; }

        private IDataAccess _data;

        public IndexModel(IDataAccess data)
        {
            this._data = data;
        }

        public void OnGet()
        {
            CurrentDate = DateTime.Now.ToShortDateString();

            List = this._data.GetProducts();
        }

        public void OnPost()
        {

        }
    }
}
