using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9_msperry6.Infrastructure;
using Mission9_msperry6.Models;

namespace Mission9_msperry6.Pages
{
    public class CheckoutModel : PageModel
    {
        private BookRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public CheckoutModel(BookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookid, string returnurl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookid).Book);

            return RedirectToPage(new { ReturnUrl = returnurl });
        }
    }
}
