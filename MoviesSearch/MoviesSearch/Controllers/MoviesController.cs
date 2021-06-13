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
        public ActionResult Search(string queryString)
        {
            var result = _client.Search<Movie>(s => s);
            if (!string.IsNullOrEmpty(queryString))
            {
                result = _client.Search<Movie>(s => s
                    .Size(25)
                    .Query(q => 
                    q.MultiMatch(
                        m => m.Fields(
                                    f => f
                            .Field(p => p.Title.Suffix("keyword"),1000)
                            .Field(p => p.Countries.Suffix("keyword"), 500)
                            .Field(p => p.Cast.Suffix("keyword"), 100)
                            .Field(p => p.Directors.Suffix("keyword"), 100)
                            .Field(p => p.Languages.Suffix("keyword"), 100)
                            .Field(p => p.Writers.Suffix("keyword"), 100)
                            .Field(p => p.Title, 1.5)
                            .Field(p => p.Storyline, 0.8)
                            .Field(p => p.Cast, 1.5)
                            .Field(p => p.Countries, 1.5)
                            .Field(p => p.Directors, 1.5)
                            .Field(p => p.Writers, 1.5)
                            )
                        .Query(queryString)
                        )


                    
                    //    .Query(query => query.MultiMatch(
                    //        m => m.Fields(
                    //            f => f
                    //        .Field(p => p.Countries.Suffix("keyword"), 500)
                    //        .Field(p => p.Cast.Suffix("keyword"), 100)
                    //        .Field(p => p.Directors.Suffix("keyword"), 100)
                    //        .Field(p => p.Languages.Suffix("keyword"), 100)
                    //        .Field(p => p.Writers.Suffix("keyword"), 100)
                    //            )
                    //        ))
                    )
                    );
            }
            /*
             * .Field(p => p.Countries.Suffix("keyword"), 500)
                                .Field(p => p.Cast.Suffix("keyword"), 100)
                                .Field(p => p.Directors.Suffix("keyword"), 100)
                                .Field(p => p.Languages.Suffix("keyword"), 100)
                                .Field(p => p.Writers.Suffix("keyword"), 100)
            */


            //.Field(p => p.Title, 1.5)
            //                    .Field(p => p.Storyline, 0.8)
            //                    .Field(p => p.Cast, 1.5)
            //                    .Field(p => p.Countries, 1.5)
            //                    .Field(p => p.Directors, 1.5)
            //                    .Field(p => p.Writers, 1.5)

            var model = new SearchViewModel
            {
                Hits = result.Hits,
                Total = result.Total,
            };

            return View(model);
        }
    }
}
