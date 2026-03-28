namespace IMDb_Movie_Management_System.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using IMDb_Movie_Management_System.Models.Request;
    using IMDb_Movie_Management_System.Services.Interfaces;

    [Authorize]
    [ApiController]
    [Route("reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewsController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
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

        [HttpGet("movie/{movieId}")]
        public IActionResult GetByMovie(int movieId)
        {
            return Ok(_service.GetByMovie(movieId));
        }

        [HttpPost]
        public IActionResult Create(ReviewRequest request)
        {
            _service.Create(request);
            return Ok("Review created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ReviewRequest request)
        {
            _service.Update(id, request);
            return Ok("Review updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Review deleted successfully");
        }
    }
}
