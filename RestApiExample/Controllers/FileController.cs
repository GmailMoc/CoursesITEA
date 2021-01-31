using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BasicInfo.Controllers
{
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("File")]
        public FileContentResult GetFile(string imageName)
        {
            byte[] fileBytes;
            if (System.IO.File.Exists($"wwwroot/{imageName}"))
            {
                fileBytes = System.IO.File.ReadAllBytes($"wwwroot/{imageName}");
            }
            else
            {
                fileBytes = System.IO.File.ReadAllBytes($"wwwroot/image-not-found.jpg");
            }

            return new FileContentResult(fileBytes, "image/jpeg");
        }

        [HttpPost("File")]
        public void UploadFile([FromBody]string file, [FromQuery]string fileName, [FromServices]IWebHostEnvironment webHost)
        {
            var filePath = Path.Combine(webHost.WebRootPath, fileName);
            var fileContent = Convert.FromBase64String(file);
            System.IO.File.WriteAllBytes(filePath, fileContent);
        }
    }
}