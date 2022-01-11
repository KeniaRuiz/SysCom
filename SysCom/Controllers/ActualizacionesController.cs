using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SysCom.Models;

namespace SysCom.Controllers
{
    public class ActualizacionesController : Controller
    {
        private bdsyscomEntities db = new bdsyscomEntities();

        // GET: Actualizaciones
        public ActionResult Index()
        {
            var actualizaciones = db.Actualizaciones.Include(a => a.recepcion);
            return View(actualizaciones.ToList());
        }

        // GET: Actualizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actualizaciones actualizaciones = db.Actualizaciones.Find(id);
            if (actualizaciones == null)
            {
                return HttpNotFound();
            }
            return View(actualizaciones);
        }

        // GET: Actualizaciones/Create
        public ActionResult Create()
        {
            ViewBag.ID_recepcion = new SelectList(db.recepcion, "ID", "Problema");
            return View();
        }

        // POST: Actualizaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_recepcion,Actualizacion")] Actualizaciones actualizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Actualizaciones.Add(actualizaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_recepcion = new SelectList(db.recepcion, "ID", "Problema", actualizaciones.ID_recepcion);
            return View(actualizaciones);
        }

        // GET: Actualizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actualizaciones actualizaciones = db.Actualizaciones.Find(id);
            if (actualizaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_recepcion = new SelectList(db.recepcion, "ID", "Problema", actualizaciones.ID_recepcion);
            return View(actualizaciones);
        }

        // POST: Actualizaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_recepcion,Actualizacion")] Actualizaciones actualizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actualizaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_recepcion = new SelectList(db.recepcion, "ID", "Problema", actualizaciones.ID_recepcion);
            return View(actualizaciones);
        }

        // GET: Actualizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actualizaciones actualizaciones = db.Actualizaciones.Find(id);
            if (actualizaciones == null)
            {
                return HttpNotFound();
            }
            return View(actualizaciones);
        }

        // POST: Actualizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actualizaciones actualizaciones = db.Actualizaciones.Find(id);
            db.Actualizaciones.Remove(actualizaciones);
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
