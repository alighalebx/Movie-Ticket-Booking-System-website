using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieTicketSystemContext movieTicketSystemContext;

        public MovieController(MovieTicketSystemContext movieTicketSystemContext)
        {
            this.movieTicketSystemContext = movieTicketSystemContext;
        }
        [HttpGet]
        public async Task<IActionResult> Getmovie()
        {
            var movie=movieTicketSystemContext.Movies.ToList();
            return Ok(movie);
        }
        [HttpGet ("getcity")]
        public async Task<IActionResult> getcity()
        {
            var city=movieTicketSystemContext.Cities.Select(p=>p.Name).ToList();
            return Ok(city);
        }
    }
}
