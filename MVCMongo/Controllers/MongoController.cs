using MVCMongo.Infrastructure;
using MVCMongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMongo.Controllers
{
    public class MongoController : Controller
    {
        
        // GET: /Mongo/

        private IMongoDepartmentDataSource _db;
        public MongoController(IMongoDepartmentDataSource MongoDepartmentDataSource)
        {
            _db = MongoDepartmentDataSource;     
        }



        public ActionResult Index()
        {            
            return View(_db.Departments);
        }

        //
        // GET: /Mongo/Details/5

        public ActionResult Details(int id)
        {
            var model = _db.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            return View(model);
        }

        //
        // GET: /Mongo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mongo/Create

        [HttpPost]
        public ActionResult Create(Department dept)
        {
            try
            {
                _db.CreateDepartment(dept);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Mongo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            List<Department> list = (from f in _db.Departments
                                     where f.DepartmentId == id
                                     select f).ToList();
            Department dept = new Department();
            if (list.Count > 0) dept = list[0];
            return View(dept);
        }

        //
        // POST: /Mongo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Department dept)
        {
            try
            {
                _db.EditDepartment(dept);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Mongo/Delete/5

        public ActionResult Delete(int id)
        {
            Department dep = (from f in _db.Departments
                              where f.DepartmentId == id
                              select f).First();
            return View(dep);
        }

        //
        // POST: /Mongo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Department collection)
        {
            try
            {
                Department dep = (from f in _db.Departments
                                  where f.DepartmentId == id
                                  select f).First();
                _db.DeleteDepartment(dep);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_db == null) _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
