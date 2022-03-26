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
            DB db = new DB();            
            ViewBag.dicts = db.GetAll();
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
            DB db = new DB();
            db.AddRecord(lastName, number);
            return Redirect("/Dict/Index");
        }



        [HttpGet]
        public ActionResult Update(int id)
        {
            DB db = new DB();
            ViewBag.record = db.Find(id);
            return View();
        }
        public ActionResult UpdateSave(int id, string lastName, string number)
        {
            DB db = new DB();
            db.Update(id, lastName, number);
            return Redirect("/Dict/Index");
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {
            DB db = new DB();
            ViewBag.record = db.Find(id);
            return View();
        }
        public ActionResult DeleteSave(int id)
        {
            DB db = new DB();
            db.Delete(id);
            return Redirect("/Dict/Index");
        }
    }
}