namespace WTM.RestApi.Models
{
    public class MovieSolution : IMovieSolution
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}