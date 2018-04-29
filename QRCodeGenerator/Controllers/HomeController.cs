using QRCodeGenerator.Helpers;
using QRCodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRCodeGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QRCode()
        {
            StudentModel studentModel = new StudentModel();
            studentModel.Address = string.Empty;

            ViewBag.Message = "Your application description page.";

            return View(studentModel);
        }

        [HttpPost]
        public ActionResult QRCode(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                var data = string.Format("{0};{1};{2}", studentModel.FirstName, studentModel.LastName,
                                            studentModel.Address);

                ViewBag.QRCodeImage = string.Format("data:image/png;base64,{0}", QRHelper.GenerateQRCode(data));
            }

            return View(studentModel);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}