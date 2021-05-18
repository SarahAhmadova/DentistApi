using MedicApp.Infrastructure.FileManager;
using MedicApp.Infrastructure.Filter;
using MedicApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Controllers.V1
{
    [ApiVersion("1.0")]
    [TypeFilter(typeof(Auth))]
    public class UploadController : BaseController
    {

        private readonly ICloudinaryService _cloudinary;
        private readonly IFileManager _fileManager;

        public UploadController(ICloudinaryService cloudinary,
                               IFileManager fileManager)
        {

            _cloudinary = cloudinary;
            _fileManager = fileManager;
        }
        [HttpPost]
        [Route("")]
        public IActionResult Uploads([FromForm] IFormFile file)
        {
            var filename = _fileManager.Upload(file);
            var publicId = _cloudinary.Store(filename);
            _fileManager.Delete(filename);

            return Ok(new
            {
                src = _cloudinary.BuildUrl(publicId)
            });
        }
    }
}
