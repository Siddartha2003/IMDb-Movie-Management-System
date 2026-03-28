using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Services.Interfaces;

namespace IMDb_Movie_Management_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("producers")]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.Get());

        [HttpPost]
        public IActionResult Create(ProducerRequest request)
        {
            _service.Create(request);
            return Ok();
        }
    }
}
