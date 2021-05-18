﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MedicApp.Services
{
    public interface ICloudinaryService
    {
        string Store(string file);
        string StoreResized(string file, int width, int height, string crop);
        string BuildUrl(string publicId, string crop = "fill", int width = 150, int height = 150);
        string BuildUrl(string publicId);
        void Delete(string publicId);
        string StoreFromUrl(string url);
    }

    public class CloudinaryService : ICloudinaryService
    {
        private readonly IConfiguration _configuration;
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            _configuration = configuration;

            var account = new Account(
                _configuration["Cloudinary:CloudName"],
                _configuration["Cloudinary:ApiKey"],
                _configuration["Cloudinary:ApiSecret"]);

            _cloudinary = new Cloudinary(account);
        }


        public string Store(string file)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "resource", "uploads", file);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(sourcePath),
                UniqueFilename = true,
                Folder = "MedicApp/",
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            return uploadResult.PublicId;
        }

        public string StoreResized(string file, int width, int height, string crop)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "resource", "temp", file);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(sourcePath),
                UniqueFilename = true,
                Folder = "MedicApp/",
                Transformation = new Transformation().Width(width).Height(height).Crop(crop)
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            return uploadResult.PublicId;
        }

        public string BuildUrl(string publicId, string crop = "fill", int width = 150, int height = 150)
        {
            return _cloudinary.Api.Url.Secure(true)
                .Transform(new Transformation().Width(width).Height(height).Crop(crop))
                .BuildUrl(publicId);
        }

        public void Delete(string publicId)
        {
            _cloudinary.DeleteResources(publicId);
        }

        public string StoreFromUrl(string url)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(url),
                UniqueFilename = true,
                Folder = "MedicApp/"
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            return uploadResult.PublicId;
        }

        public string BuildUrl(string publicId)
        {
            return _cloudinary.Api.Url.Secure(true).BuildUrl(publicId);
        }
    }
}