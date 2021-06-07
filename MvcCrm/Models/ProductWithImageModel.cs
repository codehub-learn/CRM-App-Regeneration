using CRM_App.Model;
using CRM_App.Option;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrm.Models
{
 

    public class ProductWithImageModel
    {
        public string ImageCaption { set; get; }
        public string ImageDescription { set; get; }
        public IFormFile MyImage { set; get; }
    }
}
