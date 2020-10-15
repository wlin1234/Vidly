using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Customer> customers = new List<Customer>
        {
            new Customer { Name = "John Smith" },
            new Customer { Name = "Mary Williams" }
        };
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"  };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }


        public ActionResult Customers()
        {
            var movie = new Movie() { Name = "Shrek!"  };
            var viewModel = new RandomMovieViewModel {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        [Route("movies/CustomerDetails/{index}")]
        public ActionResult CustomerDetails(int index)
        {
            if (index > this.customers.Count) return HttpNotFound();
            var viewModel = new RandomMovieViewModel {
                SelectedCustomer = this.customers[index-1]
            };
            return View("Customers", viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id" + id);
        }
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content("sortBy " + sortBy + " pageIndex " + pageIndex);
        }
    }
}