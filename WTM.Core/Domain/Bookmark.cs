using System;

namespace WTM.WebsiteClient.Domain
{
    internal class Bookmark : IWebsiteEntityBase
    {
        public DateTime ParseDateTime { get; private set; }
        public string ShotUrl { get; set; }
        public int? ShotId { get; set; }
        public string ImageUrl { get; set; }
        public int? NbDaysLeft { get; set; }
        public bool SolutionAvailable { get; set; }

        public Bookmark()
        {
            ParseDateTime = DateTime.Now;
        }
    }
}