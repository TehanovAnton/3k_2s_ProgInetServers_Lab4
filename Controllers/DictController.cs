using lab3_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace lab3_mvc.Controllers
{
    public class DictController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.dicts = DB.GetAll();
            return View();
        }



        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSave(string lastName, string number)
        {
            DB.AddRecord(lastName, number);
            return Redirect("/Dict/Index");
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.record = DB.Find(id);
            return View();
        }
        public ActionResult UpdateSave(int id, string lastName, string number)
        {
            DB.Update(id, lastName, number);
            return Redirect("/Dict/Index");
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.record = DB.Find(id);
            return View();
        }
        public ActionResult DeleteSave(int id)
        {
            DB.Delete(id);
            return Redirect("/Dict/Index");
        }
    }
}