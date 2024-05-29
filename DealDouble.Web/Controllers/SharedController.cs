﻿using DealDouble.Entities;
using DealDouble.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class SharedController : Controller
    {
        SharedService service = new SharedService();
        [HttpPost]
        public JsonResult UploadPictures()
        {
            JsonResult result = new JsonResult();
            List<object> picturesJson = new List<object>();
            var pictures = Request.Files;
            for (int i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];

                var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);

                var path = Server.MapPath("~/Content/images/") + fileName;
                
                picture.SaveAs(path);
                var dbPicture = new Picture();
                dbPicture.URL = fileName;
                int pictureID=service.SavePicture(dbPicture);

                picturesJson.Add(new { ID = pictureID, pictureURL = fileName });


            }
            result.Data = picturesJson;
            return result;
        }
    }
}