using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EasyHR.Controllers
{
    public class DisplayController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public DisplayController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public string Index(string fileName)
        {
            string filePath = Path.Combine(_environment.WebRootPath, "personel\\dosyalar", fileName);
            return System.IO.File.Exists(filePath) ? filePath : "Dosya bulunamadı!";
        }
        public FileResult Show(string path)
        {
            var uzanti = path.Split('.')[1];
            var contentType = "";
            var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

            if (uzanti == "pdf") contentType = "application/pdf";
            else if (uzanti == "doc") contentType = "application/msword";
            else if (uzanti == "docx") contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            else if (uzanti == "docx") contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            else if (uzanti == "jpeg" || uzanti == "jpg") contentType = "image/jpeg";
            else if (uzanti == "png") contentType = "image/png";
            else if (uzanti == "webp") contentType = "image/webp";

            return File(fileStream, contentType);
        }
    }
}
