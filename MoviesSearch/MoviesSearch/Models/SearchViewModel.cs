using MoviesSearch.Domain;
using Nest;
using System.Collections.Generic;

namespace MoviesSearch.Models
{
    public class SearchViewModel
    {
        public IReadOnlyCollection<IHit<Movie>> Hits { get; set; }
        public long Total { get; set; }
    }
}