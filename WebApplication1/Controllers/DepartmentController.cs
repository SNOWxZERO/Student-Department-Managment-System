using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        SchoolEntities1 db = new SchoolEntities1();
        // GET: Department
        public ActionResult Index()
        {
            List<Department> dpt = db.Department.ToList<Department>();

            return View(dpt);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int DeptID, string Deptname, int Capacity)
        {
            Department dpt = new Department() { DeptID = DeptID, Deptname = Deptname , Capacity = Capacity};
            db.Department.Add(dpt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Department dpt = db.Department.Find(id);
            return View(dpt);
        }
        [HttpPost]
        public ActionResult Edit(Department dpt)
        {
            Department s = db.Department.Find(dpt.DeptID);
            s.DeptID = dpt.DeptID;
            s.Deptname = dpt.Deptname;
            s.Capacity = dpt.Capacity;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            Department dpt = db.Department.Find(id);
            return View(dpt);
        }


        public ActionResult RemoveConfirmed(int id)
        {
            Department s = db.Department.Find(id);
            db.Department.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(401, "Id must have a value");
            Department dpt = db.Department.Find(id);
            if (dpt == null)
                return HttpNotFound();
            return View(dpt);
        }
    }
}
