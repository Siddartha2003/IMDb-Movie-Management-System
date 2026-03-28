using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Services.Interfaces;

namespace IMDb_Movie_Management_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int? year)
        {
            return Ok(_service.Get(year));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(MovieRequest request)
        {
            _service.Create(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MovieRequest request)
        {
            _service.Update(id, request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
