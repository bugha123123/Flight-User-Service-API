using BookFlight.Data;
using BookFlight.Model;
using BookFlight.Model.DBO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BookFlight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReviewsController : ControllerBase
    {

        private readonly ApplicationDbContext _reviews;

        public ReviewsController(ApplicationDbContext reviews)
        {
            _reviews = reviews;
        }

        [HttpPost("postReview")]
        public async Task<ActionResult> PostReviews(Reviews reviews)
        {
            if (reviews is null)
                return BadRequest(reviews);

            //TODO--Implement automapper logic here...
            Reviews NewReview = new()
            {
                Title = reviews.Title,
                TitleInput = reviews.TitleInput,
                MyReviews = reviews.MyReviews,
                LocationInput = reviews.LocationInput,
                Image = reviews.Image,
            };
            await _reviews.Reviews.AddAsync(NewReview);
            await _reviews.SaveChangesAsync();

            return Created(string.Empty, NewReview);
        }

        [HttpGet("GetReviews")]
        public async Task<ActionResult<List<Reviews>>> GetReviews()
        {
            List<Reviews> reviews = await _reviews.Reviews.ToListAsync();

            if (reviews.Count == 0)
                return NoContent();

            List<Reviews> result = reviews.Select(x => new Reviews
            {
                Title = x.Title,
                TitleInput = x.TitleInput,
                MyReviews = x.MyReviews,
                LocationInput = x.LocationInput,
                Image = x.Image,
            }).ToList();

            return Ok(result);
        }
    }
}
    

