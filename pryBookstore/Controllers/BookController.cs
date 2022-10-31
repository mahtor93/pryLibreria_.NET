using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using pryBookstore.Data;
using pryBookstore.Models;
using pryBookstore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;

namespace pryBookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly BooksContext _context;

        public BookController(BooksContext context)
        {
            this._context = context;
        }

        public IActionResult Index() //Permite listar los libros accesados
        {
            ListBookViewModel viewModel = new();
            List<Category> categories = _context.Categories.ToList();
            List<Book> books = _context.Books.ToList();
            viewModel.booksVM = books;
            viewModel.categoriesVM = categories;
            ViewData["categories"] = categories;
            
            return View(viewModel);
        }

        public IActionResult FindBook(string Category_BookFind)
        {
            ListBookViewModel viewModel = new();
            List<Book> books = _context.Books.ToList();
            List<Category> categories = _context.Categories.ToList(); //obtiene los datos de Categories y los añade a una lista
            viewModel.booksVM = books.Where(f => f.Category.Equals(Category_BookFind)).ToList();
            viewModel.categoriesVM = categories;
            ViewData["category_bookFind"] = categories;
            return View("Index", viewModel);
        }

        public IActionResult Create()
        {
            CreateBookViewModel viewModel = new();
            List<Category> categories = _context.Categories.ToList();
            Book book = new Book();
            viewModel.bookCVM = book;
            viewModel.categoriesCVM = categories;

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(IFormCollection formCollection)
        { 
            

            if (ModelState.IsValid)
            {
                Book book = new();
                book.Title = formCollection["bookCVM.Title"];
                book.ReleaseDate = DateTime.Parse(formCollection["releasedate"]);
                book.Author = formCollection["bookCVM.Author"];
                book.NumberPages = int.Parse(formCollection["bookCVM.NumberPages"]);
                book.Editorial = formCollection["bookCVM.Editorial"];
                book.Stock = int.Parse(formCollection["bookCVM.Stock"]);
                book.Category = formCollection["bookCVM.Category"];
                string find = book.Category;
                Category idCategoryFind = _context.Categories.FirstOrDefault(c => c.Title.Equals(find));
                book.ID_Category = idCategoryFind;
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
