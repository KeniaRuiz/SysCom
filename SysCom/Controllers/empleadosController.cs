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
    public class empleadosController : Controller
    {
        private bdsyscomEntities db = new bdsyscomEntities();

        // GET: empleados
        public ActionResult Index()
        {
            var empleados = db.empleados.Include(e => e.cActivo).Include(e => e.Tipo_Usuario);
            return View(empleados.ToList());
        }

        // GET: empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = db.empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: empleados/Create
        public ActionResult Create()
        {
            ViewBag.Estatus = new SelectList(db.cActivo, "ID", "Estatus");
            ViewBag.Tipo = new SelectList(db.Tipo_Usuario, "ID", "Tipo");
            return View();
        }

        // POST: empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Usuario,Contraseña,Estatus,Tipo")] empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estatus = new SelectList(db.cActivo, "ID", "Estatus", empleados.Estatus);
            ViewBag.Tipo = new SelectList(db.Tipo_Usuario, "ID", "Tipo", empleados.Tipo);
            return View(empleados);
        }

        // GET: empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = db.empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estatus = new SelectList(db.cActivo, "ID", "Estatus", empleados.Estatus);
            ViewBag.Tipo = new SelectList(db.Tipo_Usuario, "ID", "Tipo", empleados.Tipo);
            return View(empleados);
        }

        // POST: empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Usuario,Contraseña,Estatus,Tipo")] empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estatus = new SelectList(db.cActivo, "ID", "Estatus", empleados.Estatus);
            ViewBag.Tipo = new SelectList(db.Tipo_Usuario, "ID", "Tipo", empleados.Tipo);
            return View(empleados);
        }

        // GET: empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = db.empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empleados empleados = db.empleados.Find(id);
            db.empleados.Remove(empleados);
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
