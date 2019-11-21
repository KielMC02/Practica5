using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica_5.Models;

namespace Practica_5.Controllers
{
    public class EVENTOesController : Controller
    {
        private UTILITIES_APPEntities db = new UTILITIES_APPEntities();

        // GET: EVENTOes
        public ActionResult Index()
        {
            return View(db.EVENTOS.ToList());
        }
        [HttpPost]
        public ActionResult Index(string EVENTO)
        {


            var lista = from x in db.EVENTOS
                        select x;


            if (string.IsNullOrEmpty(EVENTO))
            {
                return View(db.CONTACTOes.ToList());
            }


            else
            {
                lista = lista.Where(a => a.descripcion.Contains(EVENTO));
                return View(lista);
            }


        }

        // GET: EVENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTOS.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // GET: EVENTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EVENTOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_evento,fecha,hora,descripcion")] EVENTO eVENTO)
        {
            if (ModelState.IsValid)
            {
                db.EVENTOS.Add(eVENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eVENTO);
        }

        // GET: EVENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTOS.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // POST: EVENTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_evento,fecha,hora,descripcion")] EVENTO eVENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eVENTO);
        }

        // GET: EVENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTOS.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // POST: EVENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVENTO eVENTO = db.EVENTOS.Find(id);
            db.EVENTOS.Remove(eVENTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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