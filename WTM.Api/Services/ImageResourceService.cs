using System;
using WTM.Crawler.Services;

namespace WTM.Api.Services
{
    public class ImageResourceService : IImageResourceService
    {
        private readonly IImageDownloader imageDownloader;
        private readonly IImageRepository imageRepository;
        private readonly IShotService shotService;
        private readonly IShotSummaryService shotSummaryService;

        public ImageResourceService(IImageDownloader imageDownloader, IImageRepository imageRepository, IShotService shotService, IShotSummaryService shotSummaryService)
        {
            this.imageDownloader = imageDownloader;
            this.imageRepository = imageRepository;
            this.shotService = shotService;
            this.shotSummaryService = shotSummaryService;
        }

        public byte[] GetThumbnail(int id)
        {
            byte[] rawData = null;//imageRepository.Get(id.ToString());
            if (rawData == null)
            {
                var imageAddress = this.GetThumbnailUri(id);
                rawData = this.GetImage(imageAddress);
                imageRepository.Add(id.ToString(), rawData);
            }

            return rawData;
        }

        public byte[] GetImage(int id)
        {
            byte[] rawData = null;//imageRepository.Get(id.ToString());
            if (rawData == null)
            {
                var imageAddress = this.GetImageUri(id);
                rawData = this.GetImage(imageAddress);
                imageRepository.Add(id.ToString(), rawData);
            }

            return rawData;
        }

        private ImageAddress GetThumbnailUri(int id)
        {
            ImageAddress imageAddress = null;

            var shotResponse = shotService.GetById(id, null);
            if (shotResponse != null)
            {
                if (shotResponse.Id != id)
                {
                    throw new NotFoundException();
                }

                var uri = new Uri(shotResponse.Image.ToString().Replace("normal", "small"));
                var referer = $"whatthemovie.com/overview/{shotResponse.PublidationDate:yyyy/MM/dd}";

                imageAddress = new ImageAddress(uri, referer);
            }

            return imageAddress;
        }

        private ImageAddress GetImageUri(int id)
        {
            ImageAddress imageAddress = null;

            var shotResponse = shotService.GetById(id, null);
            if (shotResponse != null)
            {
                if (shotResponse.Id != id)
                {
                    throw new NotFoundException();
                }

                imageAddress = new ImageAddress(shotResponse.Image, $"whatthemovie.com/shot/{id}");
            }

            return imageAddress;
        }

        private byte[] GetImage(ImageAddress imageAddress)
        {
            return this.imageDownloader.Get(imageAddress.Uri, imageAddress.Referer);
        }

        private class ImageAddress
        {
            public ImageAddress(Uri uri, string referer)
            {
                Uri = uri;
                Referer = referer;
            }

            public Uri Uri { get; private set; }

            public string Referer { get; private set; }
        }
    }
}