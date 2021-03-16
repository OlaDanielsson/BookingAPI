using BookingAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileUploadsController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnviroment;
        private readonly ILogger<FileUploadsController> logger;

        public FileUploadsController(IWebHostEnvironment webHostEnvironment, ILogger<FileUploadsController> logger)
        {
            _webHostEnviroment = webHostEnvironment;
            this.logger = logger;
        }

        [HttpPost]
        public string Post([FromForm] FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.image.Length > 0)
                {
                    string path = _webHostEnviroment.WebRootPath + "\\Uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream filestream = System.IO.File.Create(path + fileUpload.image.FileName))
                    {
                        fileUpload.image.CopyTo(filestream);
                        filestream.Flush();
                        return "Uploaded.";
                    }
                }
                else
                {
                    return "not Uploaded.";
                }
            }
            catch (Exception e)
            {
                logger.LogWarning("API couldn't handle request");
                return e.Message;
            }
        }
    }
}
