using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace scaffoldpractice.Controllers
{
    public class HomeController : Controller
    {
        viswaEntities context = new viswaEntities();
        public ActionResult Index()

        {
            viswaEntities context = new viswaEntities();
            var listofData = context.studentfiles.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(studentfile model)
        {
            context.studentfiles.Add(model);
            context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = context.studentfiles.Where(x => x.deptid == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(studentfile Model)
        {
            var data = context.studentfiles.Where(x => x.deptid == Model.stdid).FirstOrDefault();
            if (data != null)
            {
                data.stdaddress = Model.stdaddress;
                data.stdname = Model.stdname;
                data.fees = Model.fees;
                context.SaveChanges();
            }

            return RedirectToAction("index");
        }
        public ActionResult Details(int id)
        {
            var data = context.studentfiles.Where(x => x.deptid == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = context.studentfiles.Where(x => x.deptid == id).FirstOrDefault();
            context.studentfiles.Remove(data);
            context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }



    }
}