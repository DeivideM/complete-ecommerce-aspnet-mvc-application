using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTickets.Controllers;

public class MoviesController : Controller
{
    private readonly IMoviesService _service;
    public MoviesController(IMoviesService service) => _service = service;
    public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync(n => n.Cinema);
        return View(data);
    }

    public async Task<IActionResult> Filter(string searchString)
    {
        var data = await _service.GetAllAsync(n => n.Cinema);

        if (!string.IsNullOrEmpty(searchString))
        {
            var filteredResult = data.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
            return View("Index", filteredResult);
        }

        return View("Index", data);
    }

    public async Task<IActionResult> Details(int id)
    {
        var detail = await _service.GetMovieByIdAsync(id);
        return View(detail);
    }

    public async Task<IActionResult> Create()
    {
        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        //ViewData["Message"] = "Create Movie Page"; Dictionary
        //ViewBag.Description = "Create Movie Page"; Dinamic Object/Property

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewMovieVM movie)
    {
        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(movie);
        }
        await _service.AddNewMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var details = await _service.GetMovieByIdAsync(id);
        if (details == null) return View("NotFound");

        var response = new NewMovieVM()
        {
            Id = details.Id,
            Name = details.Name,
            Description = details.Description,
            Price = details.Price,
            ImageURL = details.ImageURL,
            StartDate = details.StartDate,
            EndDate = details.EndDate,
            MovieCategory = details.MovieCategory,
            CinemaId = details.CinemaId,
            ProducerId = details.ProducerId,
            ActorIds = details.Actors_Movies.Select(n => n.ActorId).ToList()
        };

        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, NewMovieVM movie)
    {
        if(id !=movie.Id) return View("NotFound");

        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(movie);
        }
        await _service.UpdateMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }
}
