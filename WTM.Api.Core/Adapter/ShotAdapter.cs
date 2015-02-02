using WTM.Domain;

namespace WTM.Api.Core.Adapter
{
    public class ShotAdapter
    {
        public static Shot ConvertToCore(WebsiteClient.Domain.Shot initialShot)
        {
            var shot = new Shot();
            shot.ShotId = initialShot.ShotId.GetValueOrDefault();
            shot.ImageUri = initialShot.ImageUrl;
            //shot.MovieId
            shot.Poster = initialShot.PostedBy;
            shot.Updater = initialShot.UpdatedBy;
            shot.FirstSolver = initialShot.FirstSolver;
            shot.NbSolver = initialShot.NbSolver.GetValueOrDefault(0);
            shot.PublidationDate = initialShot.PostedDate.GetValueOrDefault();
            shot.SolutionDate = initialShot.SolutionAvailableDate;
            //shot.Difficulty
            shot.Tags = initialShot.Tags;
            shot.Languages = initialShot.Languages;
            shot.IsGore = initialShot.Tags.Contains("gore");
            shot.IsNudity = initialShot.Tags.Contains("nudity");
            shot.Rate = new Rate
            {
                Score = initialShot.Rate.GetValueOrDefault(0), 
                NbRaters = initialShot.NbRaters.GetValueOrDefault(0)
            };

            shot.Navigation = new Navigation
            {
                FirstiId = initialShot.FirstShotId,
                PreviousId = initialShot.PreviousShotId,
                PreviousUnsolvedId = initialShot.PreviousUnsolvedShotId,
                NextUnsolvedId = initialShot.NextUnsolvedShotId,
                NextId = initialShot.NextShotId,
                LastId = initialShot.LastShotId
            };

            return shot;
        }
    }
}