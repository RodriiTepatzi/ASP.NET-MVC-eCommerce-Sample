using eCommerceTest.Data;
using eCommerceTest.Data.Services;
using eCommerceTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceTest.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var data = await _service.GetAllAsync(n => n.Cinema);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(int id, [Bind("Id, Name, Description, Price, Image, StartDate, EndDate, MovieCategory")] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            await _service.AddAsync(movie);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            return View(movieDetails);
        }
    }
}
