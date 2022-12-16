using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        [HttpGet("search by name")]
        public async Task<IActionResult> Searchbyname(String name)
        {

            var moviesearch = movieTicketSystemContext.Movies.Where(s => s.Name!.Contains(name));


            return Ok(moviesearch);

        }
        [HttpGet("search by genere")]
        public async Task<IActionResult> SearchbyGenere(String genere)
        {

            var moviesearch = movieTicketSystemContext.Movies.Where(s => s.Genre!.Contains(genere));


            return Ok(moviesearch);
        }
        [HttpGet("search by Language")]
        public async Task<IActionResult> Searchbylanguage(String language)
        {

            var moviesearch = movieTicketSystemContext.Movies.Where(s => s.Language!.Contains(language));


            return Ok(moviesearch);
        }
        [HttpGet("search by releasedate")]
        public async Task<IActionResult> Searchbydate(String date)
        {

            var moviesearch = movieTicketSystemContext.Movies.Where(s => s.Realeasedate!.Contains(date));


            return Ok(moviesearch);
        }
        [HttpGet("get shows")]
        public async Task<IActionResult> returnshows(String name)
        {

            var id = from Movie in movieTicketSystemContext.Movies select Movie.MoiveId;
              var dee = id.Where(name.Equals(movieTicketSystemContext.Name)
        }



    }
}
