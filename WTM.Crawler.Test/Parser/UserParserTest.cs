using NFluent;
using NUnit.Framework;
using WTM.Crawler.Parsers;
using WTM.Domain;

namespace WTM.Crawler.Test.Parser
{
    [TestFixture]
    public class UserParserTest
    {
        [Test]
        public void WhenParseUserPageThenReturnValidEntity()
        {
            ParseUserAndDoBasisCheck("alex68");
            ParseUserAndDoBasisCheck("Asmodai");
            ParseUserAndDoBasisCheck("CaptainOblivious");
            ParseUserAndDoBasisCheck("MisterZob");
            ParseUserAndDoBasisCheck("RDPL55");
            ParseUserAndDoBasisCheck("Scruffy");
        }

        private User ParseUserAndDoBasisCheck(string name)
        {
            var user = ParseUser(name);
            Check.That(user).IsNotNull();
            Check.That(user.Name).Equals(name);
            Check.That(user.Level).IsNotNull();
            Check.That(user.Score).IsNotNull();
            Check.That(user.FeatureFilmsSolved).IsNotNull();
            Check.That(user.SnapshotSolved).IsNotNull();
            Check.That(user.ReceivingRating).IsNotNull();
            Check.That(user.FavouritedRating).IsNotNull();
            Check.That(user.UploadFeatureFilmSnapshots).IsNotNull();
            Check.That(user.UploadSnapshotsOfTheDay).IsNotNull();
            Check.That(user.UploadVaultSnapshots).IsNotNull();
            Check.That(user.UploadRejectedSnapshots).IsNotNull();
            Check.That(user.UploadCharacterSnapshots).IsNotNull();
            Check.That(user.UploadTitleSnapshots).IsNotNull();
            Check.That(user.UploadReplacementSnapshots).IsNotNull();
            Check.That(user.FavouriteSnapshots).IsNotNull();
            Check.That(user.FavouriteMovies).IsNotNull();
            Check.That(user.FavouriteCharacters).IsNotNull();
            Check.That(user.FavouriteSeries).IsNotNull();
            Check.That(user.Friends).IsNotNull();
            Check.That(user.MemorabiliaList).IsNotNull();
            Check.That(user.ImageUri).IsNotNull();
            return user;
        }

        private User ParseUser(string username)
        {
            var resourceName = string.Format("Resources/Users/{0}.html", username);
            return CreateParserWithFakeFile(resourceName).GetByUsername(username);
        }

        private UserParser CreateParserWithFakeFile(string htmlFilePath)
        {
            return new UserParser(new WebClientFake(htmlFilePath), new HtmlParser());
        }
    }
}