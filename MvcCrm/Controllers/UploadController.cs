using CRM_App.Database;
using CRM_App.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCrm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MvcCrm.Controllers
{
    public class UploadController : Controller
    {

        private readonly ILogger<UploadController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly CrmDbContext _db;
        public UploadController(ILogger<UploadController> logger, IWebHostEnvironment environment
            , CrmDbContext db)
        {
            _hostingEnvironment = environment;
            _logger = logger;
            _db = db;
        }

        // GET: Upload
        public ActionResult Index()
        {
            List<ProductWithImage> productWithImageModels
                = _db.ProductWithImages.ToList();

            return View(productWithImageModels);
        }

        // GET: Upload/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Upload/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Upload/Create
        // https://stackoverflow.com/questions/35379309/how-to-upload-files-in-asp-net-core
        [HttpPost]
        [ValidateAntiForgeryToken]   // cannot be used in ajax call
        public ActionResult<ProductWithImageModel> Create([FromForm] ProductWithImageModel model)
        {

            // do other validations on your model as needed
            if (model.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(model.MyImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img", uniqueFileName);
           
                model.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

                ProductWithImage product = new(){ 
                    Description=model.ImageDescription,
                    FileName = uniqueFileName,
                    Name = model.ImageCaption
                };

                _db.ProductWithImages.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index", "Upload");
            }
            return NotFound();
        }

        // POST: Upload/Create
        // https://stackoverflow.com/questions/35379309/how-to-upload-files-in-asp-net-core
        [HttpPost]
        //    [ValidateAntiForgeryToken]   // cannot be used in ajax call
        public  ProductWithImage CreateFromAjaxWithFormData([FromForm] ProductWithImageModel model)

        {

            // do other validations on your model as needed
            if (model.MyImage != null)
            {
                var uniqueFileName = GetUniqueFileName(model.MyImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img", uniqueFileName);

                model.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));

                ProductWithImage product = new()
                {
                    Description = model.ImageDescription,
                    FileName = uniqueFileName,
                    Name = model.ImageCaption
                };

                _db.ProductWithImages.Add(product);
                _db.SaveChanges();
                return product;
            }
            return null;
        }


        private static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

    }
}
