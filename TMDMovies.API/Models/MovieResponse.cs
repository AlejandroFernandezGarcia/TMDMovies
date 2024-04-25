namespace TMDMovies.API.Models
{
    public class MovieResponse
    {
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string ScoreAverage { get; set; }
        public DateTime ReleaseDAte { get; set; }
        public string Synopsis { get; set; }
        public List<string> RelatedMovies { get; set; }
    }
}
