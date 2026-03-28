using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Services.Interfaces;

namespace IMDb_Movie_Management_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("genres")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenresController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _service.Get(id);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(GenreRequest request)
        {
            _service.Create(request);
            return Ok("Genre created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, GenreRequest request)
        {
            _service.Update(id, request);
            return Ok("Genre updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Genre deleted successfully");
        }
    }
}
