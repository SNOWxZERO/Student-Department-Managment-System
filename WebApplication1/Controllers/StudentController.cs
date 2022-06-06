using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        SchoolEntities1 db = new SchoolEntities1();

        public ActionResult Index()
        {
            List<Student> std = db.Student.ToList<Student>();

            return View(std);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name, int id,string mail,string phon,int dep_id)
        {
            Student std = new Student() { name = name, id = id,mail=mail,phon= phon,dep_id=dep_id };
            db.Student.Add(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student std = db.Student.Find(id);
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            Student s = db.Student.Find(std.id);
            s.name = std.name;
            s.id = std.id;
            s.mail = std.mail;
            s.phon = std.phon;
            s.dep_id = std.dep_id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            Student std = db.Student.Find(id);
            return View(std);
        }
        

        public ActionResult RemoveConfirmed(int id)
        {
            Student s = db.Student.Find(id);
            db.Student.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(401, "ID must have a value");
            Student std = db.Student.Find(id);
            if (std == null)
                return HttpNotFound();
            return View(std);
        }
    }
}