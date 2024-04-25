using Newtonsoft.Json;

namespace TMDMovies.ExternalServices.Models
{
    public class TMDBMovieResponse
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("vote_average")]
        public float ScoreAverage { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDAte { get; set; }

        [JsonProperty("overview")]
        public string Synopsis { get; set; }

        //id": 80500,
    }
}