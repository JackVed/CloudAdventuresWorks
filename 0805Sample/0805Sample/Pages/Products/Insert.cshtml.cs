using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _0805Sample.Data;
using _0805Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _0805Sample.Pages.Products
{
    [IgnoreAntiforgeryToken]//in questo caso sol ingnoriamo, ma dovrebbe essere inserito con l'oggetto che arriva in post

    public class InsertModel : PageModel
    {
        public Product List { get; set; }

        private IDataAccess _data;

        public InsertModel(IDataAccess data)
        {
            this._data = data;
        }

        [BindProperty]/*in modo automatico va a cercarsi i valori tra quelli che arrivano dal post*/
        public ProductInsertInput Input { get; set;}

        //questa classe ora mi serve solo qui, ma se mi servisse in diverse pagine si crea un cs a parte
        public class ProductInsertInput
        {
            //[Display(Name = "Code")]
            //[Required]
            //[StringLength(6, MinimumLength = 3)]
            //public string Code { get; set; }

            [Display(Name = "Name")]
            [Required]
            [StringLength(250)]
            public string Name { get; set; }

            [Display(Name = "ProductNumber")]
            [Required]
            public string ProductNumber { get; set; }

            [Display(Name = "StandardCost")]
            [DataType(DataType.Currency)]
            public int StandardCost { get; set; }
            //punto di domanda perchè non è obbligatorio

            [Display(Name = "ListPrice")]
            [DataType(DataType.Currency)]
            public int ListPrice { get; set; }

            [Display(Name = "SellStartDate")]
            [Required]
            public DateTime SellStartDate { get; set; }
        }

        public void OnGet()
        {
            Input = new ProductInsertInput();
        }

        public IActionResult OnPost(ProductInsertInput productInput)
        {
            if(Input.Name == "123")//questa è una validazione lato server
            {
                ModelState.AddModelError("Input.Code", "Il codice non può essere 123.");
            }
            if(ModelState.IsValid)
            {
                //salvo su db
                Product p = new Product(Input.Name, Input.ProductNumber, Input.StandardCost, Input.ListPrice, Input.SellStartDate);
                this._data.PostProduct(p);
                return RedirectToPage("/Index");//torna alla pagina Index
            }
            //nel caso di errori ritorno alla pagina corrente. Avviene già una validazione lato client ma
            //questa la rende meno vulnerabile.
            return Page();

        }

        public IActionResult OnPostGetMessage()
        {
            //ritorno di un json con questi dati
            return new JsonResult(new
            {
                Result = true,
                Message = $"Ciao, sono le ore {DateTime.Now.ToShortTimeString()}"
            });
        }

        public IActionResult OnPoStSubscribe(string mail)
        {
            //preferibile al return page() perchè questo dopo il suo utilizzo mantiene l'indirizzo
            return RedirectToPage("Insert");
        }
    }
}