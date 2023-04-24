namespace MovieReviewCore.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Released { get; set; }
        public int Rating { get; set; }
    }
}
