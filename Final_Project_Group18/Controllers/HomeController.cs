using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Final_Project_Group18.DAL;
using Final_Project_Group18.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Drawing;

namespace Final_Project_Group18.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public ActionResult DisplaySearchResults(SearchViewModel svm)
        {
            var query = from b in _context.Books
                        select b;

            // searching by title or author
            if (svm.SearchTitle != null && svm.SearchTitle != "") //if user entered something
            {
                //return results where Title or Author has the input
                query = query.Where(b => b.Title.Contains(svm.SearchTitle) ||
                                     b.Author.Contains(svm.SearchTitle));
            }

            // filter by description 
            if (svm.SearchDescription != null && svm.SearchDescription != "") //if user entered something
            {
                //return results where Title or Author has the input
                query = query.Where(b => b.Description.Contains(svm.SearchDescription));
            }

            // filter by format 
            if (svm.SelectedFormat != null)
            {
                if (svm.SelectedFormat == Format.Paperback) //if user chose paperback
                {
                    //return results where Title or Author has the input
                    query = query.Where(c => c.BookFormat == Format.Paperback);
                }
                else //if user chose hardback
                {
                    //return results where Title or Author has the input
                    query = query.Where(c => c.BookFormat == Format.Hardback);
                }
            }

            // filter by genre
            if (svm.SelectedGenreID != 0) //if user entered something
            {
                Genre ChosenGenre = _context.Genres.Find(svm.SelectedGenreID);
                
                // TODO
                query = query.Where(c => c.Genre == ChosenGenre);
            }

            // filter by price
            if (svm.SearchPrice != null) // if user entered value for price
            {
                if (svm.SelectedType == BookType.GreaterThan)
                {
                    query = query.Where(c => c.Price >= svm.SearchPrice);
                }
                else if (svm.SelectedType == BookType.GreaterThan)
                {
                    query = query.Where(c => c.Price <= svm.SearchPrice);
                }
            }
            // filter by released after date
            if (svm.SelectedDate != null)
             {
                 query = query.Where(c => c.PublishedDate >= svm.SelectedDate);
             }
            

            // Execute query
            List<Book> SelectedBooks = query.ToList();

            //Populate the view bag with a count of all books
            ViewBag.AllBooks = _context.Books.Count();
            //Populate the view bag with a count of selected books
            ViewBag.SelectedBooks = SelectedBooks.Count;

            return View("Index",SelectedBooks.OrderBy(s => s.Title));
        }

        public ActionResult DetailedSearch()
        {
            // populate view bag with list of genres
            ViewBag.AllGenres = GetAllGenresSelectList();

            //Set default properties
            SearchViewModel svm = new SearchViewModel();
            svm.SelectedGenreID = 0;

            return View();
        }
        // GET: Home
        public ActionResult Index(String SearchString)
        {
            // LINQ query to filter books we want
            var query = from b in _context.Books
                        select b;

            // check if SearchString is null
            // if yes, then display all records
            if (SearchString == null)
            {
                query = query;
            }
            // else, limit query to books whose title/desc contains requested string
            else
            {
                query = query.Where(b => b.Title.Contains(SearchString) ||
                                    b.Description.Contains(SearchString));
            }

            // Execute query
            List<Book> SelectedBooks = query.Include(b => b.Genre).ToList();

            //Populate the view bag with a count of all books
            ViewBag.AllBooks = _context.Books.Count();
            //Populate the view bag with a count of selected books
            ViewBag.SelectedBooks = SelectedBooks.Count;

            return View(SelectedBooks.OrderBy(s => s.Title));
        }

        public IActionResult Details(int? id)//id is the id of the book you want to see
        {
            if (id == null) //BookID not specified
            {
                //user did not specify a BookID – take them to the error view
                return View("Error", new String[] { "BookID not specified - which book do you want to view?" });
            }
            //look up the book in the database based on the id; be sure to include the genre
            Book book = _context.Books.Include(b => b.Genre)
                .FirstOrDefault(b => b.BookID == id);
            if (book == null) //No book with this id exists in the database
            {
                //there is not a book with this id in the database – show the user an error view
                return View("Error", new String[] { "Book not found in database" });
            }
            //if code gets this far, all is well – display the details
            return View(book);
        }

        private SelectList GetAllGenresSelectList()
        {
            //Get the list of genres from the database
            List<Genre> genreList = _context.Genres.ToList();

            //add a dummy entry so the user can select all genres
            Genre SelectNone = new Genre() { GenreID = 0, GenreName = "All Genres" };
            genreList.Add(SelectNone);

            //convert the list to a SelectList by calling SelectList constructor
            //GenreID and GenreName are the names of the properties on the Genre class
            //GenreID is the primary key
            SelectList genreSelectList = new SelectList(genreList.OrderBy(a => a.GenreID), "GenreID", "GenreName");

            return genreSelectList;

        }
    }
}
