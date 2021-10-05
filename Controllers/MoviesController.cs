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
    }
}
