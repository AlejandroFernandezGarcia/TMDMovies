using Newtonsoft.Json;

namespace TMDMovies.ExternalServices.Models
{
    public class TMDBMovieResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("vote_average")]
        public float ScoreAverage { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("overview")]
        public string Synopsis { get; set; }
    }
}