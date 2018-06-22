using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASPMVC_MSSQL_GRID_CRUD.Models;
using System.Net;

namespace ASPMVC_MSSQL_GRID_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private GridModel db = new GridModel();
        public ActionResult RenderGrid()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        //public ActionResult Edit([Bind(Include = "CustomerID,CompanyName")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(customer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("RenderGrid");
        //    }
        //    return View(customer);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
         
        }
    }
}