using databeses.Data;
using databeses.Dtos;
using databeses.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EGener = databeses.Dtos.EGener;
using Movie = databeses.Dtos.Movie;
namespace databeses.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController: ControllerBase 
{
    private ILogger<MoviesController> _logger;
    private AppDbContext _context;

    public MoviesController(ILogger<MoviesController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok( await _context.Movies.ToListAsync());
    }
    [HttpPut]
    public async Task<IActionResult> GetById(Guid id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        movie.Viewed++;
        await _context.SaveChangesAsync();
        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Dtos.Movie movie)
    {
        var entity = new Movie()
        {
            Title = movie.Title,
            Discription = movie.Discription,
            ReleaseDate = movie.ReleaseDate,
            Imdb = movie.Imdb,
            Viewed = movie.Viewed,
            Gener = movie.Gener switch
            {
                databeses.Dtos.EGener.Action => EGener.Action,
                databeses.Dtos.EGener.Horror => EGener.Horror,
                databeses.Dtos.EGener.Comedy => EGener.Comedy,
            },
        };
        
        await _context.SaveChangesAsync();        
        return CreatedAtAction(nameof(Create), entity);
    }

}