using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesSearch.Domain;
using MoviesSearch.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesSearch.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IElasticClient _client;

        public MoviesController(IElasticClient client)
        {
            _client = client;
        }

        // GET: MoviesController
        public ActionResult Search()
        {
            var result = _client.Search<Movie>(s => s);
            var model = new SearchViewModel
            {
                Hits = result.Hits,
                Total = result.Total,
            };

            return View(model);
        }
    }
}
