namespace Movies.API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Gener { get; set; }
        public DateTime RelaseDate { get; set; }
        public string Owner { get; set; }
        public string Rating { get; set; }
        public string ImageUrl { get; set; }
        
    }
}
