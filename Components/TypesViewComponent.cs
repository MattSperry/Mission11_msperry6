using Microsoft.AspNetCore.Mvc;
using Mission9_msperry6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_msperry6.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private BookRepository repo { get; set; }

        public TypesViewComponent (BookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData.Values["Category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
