using eCommerceTest.Data;
using eCommerceTest.Data.Services;
using eCommerceTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<ActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResults = data.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResults);
            }

            return View("Index", data);
        }

        public async Task<IActionResult> Create()
        {
            var moviewDropdownData = await _service.GetNewMoviewDropdownsValue();

            ViewBag.CinemaId = new SelectList(moviewDropdownData.Cinemas, "Id", "Name");
            ViewBag.ActorId = new SelectList(moviewDropdownData.Actors, "Id", "FullName");
            ViewBag.ProducerId = new SelectList(moviewDropdownData.Producers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviewDropdownData = await _service.GetNewMoviewDropdownsValue();

                ViewBag.CinemaId = new SelectList(moviewDropdownData.Cinemas, "Id", "Name");
                ViewBag.ActorId = new SelectList(moviewDropdownData.Actors, "Id", "FullName");
                ViewBag.ProducerId = new SelectList(moviewDropdownData.Producers, "Id", "FullName");

                return View();
            }

            await _service.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            return View(movieDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                Image = movieDetails.Image,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            var moviewDropdownData = await _service.GetNewMoviewDropdownsValue();

            ViewBag.CinemaId = new SelectList(moviewDropdownData.Cinemas, "Id", "Name");
            ViewBag.ActorId = new SelectList(moviewDropdownData.Actors, "Id", "FullName");
            ViewBag.ProducerId = new SelectList(moviewDropdownData.Producers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var moviewDropdownData = await _service.GetNewMoviewDropdownsValue();

                ViewBag.CinemaId = new SelectList(moviewDropdownData.Cinemas, "Id", "Name");
                ViewBag.ActorId = new SelectList(moviewDropdownData.Actors, "Id", "FullName");
                ViewBag.ProducerId = new SelectList(moviewDropdownData.Producers, "Id", "FullName");

                return View();
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
