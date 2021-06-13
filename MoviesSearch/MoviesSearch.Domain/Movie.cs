using Nest;
using System;

namespace MoviesSearch.Domain
{
    public class Movie
    {
        [PropertyName("cast")]
        public string[] Cast { get; set; }

        [PropertyName("countries")]
        public string[] Countries { get; set; }
        
        [PropertyName("directors")]
        public string[] Directors { get; set; }

        [PropertyName("languages")]
        public string[] Languages { get; set; }

        [PropertyName("writers")]
        public string[] Writers { get; set; }

        [PropertyName("duration")]
        public long Duration { get; set; }

        [PropertyName("movie_url")]
        public string MovieUrl { get; set; }
        
        [PropertyName("rating")]
        public double Rating { get; set; }

        [PropertyName("released_date")]
        public DateTime ReleasedDate { get; set; }

        [PropertyName("storyline")]
        public string Storyline { get; set; }
        
        [PropertyName("title")]
        public string Title { get; set; }
    }
}
