﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

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
            //var moviename = movieTicketSystemContext.Movies.Select(s => s.Name==name);
            var moviename = from a in movieTicketSystemContext.Shows
                            join b in movieTicketSystemContext.Movies
                            on a.MovieId equals b.MoiveId
                            //from c in movieTicketSystemContext.CinemaHalls
                            //join d in movieTicketSystemContext.Cinemas
                            //on c.CinemaId equals d.CinemaId
                            join c in movieTicketSystemContext.CinemaHalls
                            on a.CinemaHallId equals c.CinemaHallId
                            join d in movieTicketSystemContext.Cinemas
                            on c.CinemaId equals d.CinemaId
 
                            where b.Name == name
                            select new
                            {
                                MovieId = a.MovieId,
                                showid = a.ShowId,
                                starttime = a.StartTime,
                                endtime = a.EndTime,
                                hallid = a.CinemaHallId,
                                cinema=d.Name
                            };
            return Ok(moviename);

        }
        [HttpGet("retrun show seats")]
        public async Task<IActionResult> returnshowseats(int showid)
        {
            //var seats= from a in movieTicketSystemContext.CinemaHalls
            //           join b in movieTicketSystemContext.CinemaSeats
            //           on a.CinemaHallId equals b.CinemaHallId
            //           join c in movieTicketSystemContext.ShowSeats
            //           on b.CinemaSeatId== c.CinemaSeatId
            //           select new
            //           {

            //           }
            //var seats =  from f in movieTicketSystemContext.Shows
            //             join g in movieTicketSystemContext.ShowSeats
            //             on f.ShowId equals g.ShowId
            //    from a in movieTicketSystemContext.CinemaHalls
            //            join b in movieTicketSystemContext.CinemaSeats
            //                on a.CinemaHallId equals b.CinemaHallId
            //            join c in movieTicketSystemContext.ShowSeats
            //              on b.CinemaSeatId equals c.CinemaSeatId

            //            where b.CinemaSeatId == c.CinemaSeatId
            //            select new
            //            {
            //                type = b.Type,
            //                status = c.Status,
            //                price = c.Price

            //            };
            var seats = from a in movieTicketSystemContext.ShowSeats
                        join b in movieTicketSystemContext.CinemaSeats
                        on a.CinemaSeatId equals b.CinemaSeatId
                        where a.ShowId == showid
                        select new
                        {
                            type = b.Type,
                            status = a.Status,
                            price = a.Price,
                            seatno=a.CinemaSeatId
                        };






            return Ok(seats);



        }
        [HttpPut("choose seat")]
        public async Task<IActionResult> chooseseats(int seatid)
        {
            var seat = movieTicketSystemContext.ShowSeats.Where(a => a.CinemaSeatId == seatid).Select(a => a.Status);
            var f = (from a in movieTicketSystemContext.ShowSeats
                     where a.CinemaSeatId == seatid
                     select a).FirstOrDefault();
            if (seat.Contains(0))
            {
                return Ok("This seat is reserved");
            }
            else
            {
                f.Status = 0;
                movieTicketSystemContext.SaveChanges();
                return Ok("done");

            }




            return Ok();




        }

        [HttpPost("f")]
        public async Task<IActionResult> chooseseat([FromForm]seatsdto dto)
        {

                var queueDataTable = movieTicketSystemContext.Bookings;
                var lastDataRow = queueDataTable.AsEnumerable().Last();
                movieTicketSystemContext.Add(new Booking()
                {
                    BookingId = lastDataRow.BookingId + 1,
                    NumberOfSeats = dto.NumberOfSeats,
                    Timestamp = dto.Timestamp,
                    Status = dto.Status,
                    UserId = dto.UserId,
                });



                movieTicketSystemContext.SaveChanges();
                return Ok();


            }


        [HttpPost ("Email")]
        public async Task<IActionResult> SendEmail(string Emaill)
       
        {

            string body = "Your booking is succeufly done";
            string emailll = "alighaleb2001@gmail.com";
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("alighaleb2001@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailll));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Text) { Text = body };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("alighaleb2001@gmail.com", "gvfljihvlqvlzxhk");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();

        }



        }



    }

