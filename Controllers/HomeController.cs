﻿using Microsoft.AspNetCore.Mvc;
using Mission9_msperry6.Models;
using Mission9_msperry6.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_msperry6.Controllers
{
    public class HomeController : Controller
    {
        private BookRepository repo;
        
        public HomeController (BookRepository temp)
        {
            repo = temp;
        }
        //private BookstoreContext context { get; set; }

        //public HomeController(BookstoreContext temp) => context = temp;

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == bookCategory || bookCategory == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (
                    bookCategory == null
                    ? repo.Books.Count()
                    : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
