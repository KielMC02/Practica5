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
    public class ESTUDIANTEsController : Controller
    {
        private UTILITIES_APPEntities db = new UTILITIES_APPEntities();

        public ActionResult Bienvenida()
        {
            return View();
        }

        // GET: ESTUDIANTES
        //Este Metodo Carga el Listado de Estudiantes Inscritos
        public ActionResult Consultar_Materias()
        {
            return View(db.ESTUDIANTES.ToList());
        }
        //Este metodo mustras las Materias seleccionadas por el estudiante seleccionado(Valga la Redundancia)
        public ActionResult Mostrar_Materias(int? id_estudiante)
        {
            if(id_estudiante == null)
            {
                return RedirectToAction("Consultar_Materias");
            }
            //La Variable lista_materias almacena una lista de todas las materias que tienen el id del estudiante seleccionado
            var materia_estudiantes = (from x in db.ESTUDIANTES_MATERIAS
                                       where x.ID_estudiante == id_estudiante
                                       select x);
           
          
            return View(materia_estudiantes);

        }

        ////// GET: ESTUDIANTEs/Details/5

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ESTUDIANTE eSTUDIANTE = db.ESTUDIANTES.Find(id);
        //    if (eSTUDIANTE == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(eSTUDIANTE);
        //}

        //// GET: ESTUDIANTEs/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ESTUDIANTEs/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID_estudiante,nombre,apellido,edad,sexo,carrera")] ESTUDIANTE eSTUDIANTE)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ESTUDIANTES.Add(eSTUDIANTE);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(eSTUDIANTE);
        //}

        //// GET: ESTUDIANTEs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ESTUDIANTE eSTUDIANTE = db.ESTUDIANTES.Find(id);
        //    if (eSTUDIANTE == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(eSTUDIANTE);
        //}

        //// POST: ESTUDIANTEs/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID_estudiante,nombre,apellido,edad,sexo,carrera")] ESTUDIANTE eSTUDIANTE)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(eSTUDIANTE).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(eSTUDIANTE);
        //}

        //// GET: ESTUDIANTEs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ESTUDIANTE eSTUDIANTE = db.ESTUDIANTES.Find(id);
        //    if (eSTUDIANTE == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(eSTUDIANTE);
        //}

        //// POST: ESTUDIANTEs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ESTUDIANTE eSTUDIANTE = db.ESTUDIANTES.Find(id);
        //    db.ESTUDIANTES.Remove(eSTUDIANTE);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
