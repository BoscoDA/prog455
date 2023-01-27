using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week1.Models;

namespace Week1.Controllers
{
    public class MovieQuoteController : Controller
    {
        static List<MovieQuoteModel> quotes;

        // GET: MovieQuoteController
        public ActionResult Index()
        {
            if(quotes == null)
            {
                quotes = new List<MovieQuoteModel>();
                quotes.Add(new MovieQuoteModel() { Quote = "It's Over, Anakin. I Have The High Ground.", Character = "Obi-Wan Kenobi"});
                quotes.Add(new MovieQuoteModel() { Quote = "Hello there.", Character = "Obi-Wan Kenobi" });
                quotes.Add(new MovieQuoteModel() { Quote = "I Don't Like Sand. It's Coarse And Rough And Irritating, And It Gets Everywhere.", Character = "Anakin Skywalker" });
                quotes.Add(new MovieQuoteModel() { Quote = "Be excellent to each other. And party on dudes!", Character = "Bill and Ted" });
                quotes.Add(new MovieQuoteModel() { Quote = "Pizza time.", Character = "Peter Parker" });
                quotes.Add(new MovieQuoteModel() { Quote = "You shall not cross!", Character = "Gandalf" });
                quotes.Add(new MovieQuoteModel() { Quote = "Get to the chopper!", Character = "Dutch" });
                quotes.Add(new MovieQuoteModel() { Quote = "You're a wizard, Harry.", Character = "Rubeus Hagrid" });
                quotes.Add(new MovieQuoteModel() { Quote = "Here's Johnny!", Character = "Jack Torrance" });
                quotes.Add(new MovieQuoteModel() { Quote = "Live or die... Make your choice.", Character = "Jigsaw" });
            }

            Random random = new Random();
            int randQuoteIndex = random.Next(0, quotes.Count);

            return View(quotes[randQuoteIndex]);
        }
    }
}
