namespace WTM.Core.Services
{
    internal class ShowSolutionResponse : IServiceResponse
    {
        public bool IsSuccess { get; private set; }

        public string OriginalTitle { get; set; }
        public int Year { get; set; }
        public string MovieLink { get; set; }
    }
}
