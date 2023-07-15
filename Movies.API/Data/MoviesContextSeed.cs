using Movies.API.Models;

namespace Movies.API.Data
{
    public class MoviesContextSeed
    {
        public static void SeedAsync(MoviesAPIContext moviesContext)
        {
            var movies = new List<Movie>()
            {
                new Movie
                {
                    Id=1,
                    Gener="Drama",
                    Title="the shae",
                    Rating="9.3",
                    ImageUrl="Image/src",
                    RelaseDate=new DateTime(1994,5,13),
                    Owner="alic"
                },  new Movie
                {
                    Id=2,
                    Gener="crime",
                    Title="the good father",
                    Rating="9.3",
                    ImageUrl="Image/src",
                    RelaseDate=new DateTime(1972,5,13),
                    Owner="alic"
                },  new Movie
                {
                    Id=3,
                    Gener="Action",
                    Title="the ffdsf",
                    Rating="9",
                    ImageUrl="Image/src",
                    RelaseDate=new DateTime(1994,5,13),
                    Owner="alic"
                },  new Movie
                {
                    Id=4,
                    Gener="ROMQNIC",
                    Title="the fafge",
                    Rating="9.1",
                    ImageUrl="Image/src",
                    RelaseDate=new DateTime(1994,5,13),
                    Owner="alic"
                }
                
            };
            moviesContext.Movie.AddRange(movies);
            moviesContext.SaveChanges();
        }
    }
}
