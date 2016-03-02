﻿namespace WTM.Api.Services
{
    public interface IImageResourceService
    {
        byte[] GetThumbnail(int id);
        byte[] GetImage(int id);
    }
}