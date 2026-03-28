using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Services.Interfaces;

namespace IMDb_Movie_Management_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("actors")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _service;

        public ActorsController(IActorService service)
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
        public IActionResult Create(ActorRequest request)
        {
            _service.Create(request);
            return Ok("Actor created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ActorRequest request)
        {
            _service.Update(id, request);
            return Ok("Actor updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Actor deleted successfully");
        }
    }
}
