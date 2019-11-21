using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica_5.Models;

namespace Practica_5.Controllers
{
    public class CONTACTOesController : Controller
    {
        private UTILITIES_APPEntities db = new UTILITIES_APPEntities();

        // GET: CONTACTOes
        public ActionResult Index()
        {
            return View(db.CONTACTOes.ToList());
        }

        [HttpPost]
        public ActionResult Index(string Telbusqueda, string Nombusqueda)
        {


            var lista = from x in db.CONTACTOes
                        select x;
            var lista2 = from y in db.CONTACTOes
                         select y;

            if (string.IsNullOrEmpty(Telbusqueda) && string.IsNullOrEmpty(Nombusqueda))
            {
                return View(db.CONTACTOes.ToList());
            }
            else if (Nombusqueda != null)
            {
                lista2 = lista2.Where(a => a.nombre.Contains(Nombusqueda));
                return View(lista2);

            }

            else
            {
                lista = lista.Where(a => a.celular.Contains(Telbusqueda));
                return View(lista);
            }


        }

        // GET: CONTACTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTOes.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // GET: CONTACTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CONTACTOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_contacto,nombre,celular,email,direccion")] CONTACTO cONTACTO)
        {
            if (ModelState.IsValid)
            {
                db.CONTACTOes.Add(cONTACTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cONTACTO);
        }

        // GET: CONTACTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTOes.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // POST: CONTACTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_contacto,nombre,celular,email,direccion")] CONTACTO cONTACTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTACTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cONTACTO);
        }

        // GET: CONTACTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTOes.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // POST: CONTACTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CONTACTO cONTACTO = db.CONTACTOes.Find(id);
            db.CONTACTOes.Remove(cONTACTO);
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

        public ActionResult Importar()
        {
            return View(new List<CustomerModel>());
        }

        [HttpPost]
        public ActionResult Importar(HttpPostedFileBase postedFile, string path)
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            string filePath = string.Empty;
            if (postedFile != null)
            {
                path = Server.MapPath("~/Uploads/" + postedFile.FileName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);

                foreach (string row in csvData.Split('\n'))
                {

                    if (!string.IsNullOrEmpty(row))
                    {
                        customers.Add(new CustomerModel
                        {

                            ID = int.Parse(row.Split(',')[0].ToString().Replace("-", " ").Trim()),
                            Nombre = row.Split(',')[1],
                            Apellido = row.Split(',')[2],
                            Telefono = row.Split(',')[3],
                            Direccion = row.Split(',')[4],
                            Edad = int.Parse(row.Split(',')[5].ToString().Replace("-", " ").Trim()),
                            Sexo = row.Split(',')[6]

                        }); ;

                    }
                }
            }
            return View(customers);
        }

    }
}