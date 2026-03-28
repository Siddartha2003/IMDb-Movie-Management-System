namespace IMDb_Movie_Management_System.Models.Response
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }

        public List<string> Actors { get; set; }
        public List<string> Genres { get; set; }
        public string Producer { get; set; }
    }
}
