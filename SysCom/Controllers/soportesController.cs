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
    public class soportesController : Controller
    {
        private bdsyscomEntities db = new bdsyscomEntities();

        // GET: soportes
        public ActionResult Index()
        {
            var soporte = db.soporte.Include(s => s.cEstatus).Include(s => s.clientes).Include(s => s.empleados).Include(s => s.empleados1);
            return View(soporte.ToList());
        }

        // GET: soportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            soporte soporte = db.soporte.Find(id);
            if (soporte == null)
            {
                return HttpNotFound();
            }
            return View(soporte);
        }

        // GET: soportes/Create
        public ActionResult Create()
        {
            ViewBag.Estatus = new SelectList(db.cEstatus, "ID", "estatus");
            ViewBag.Cliente = new SelectList(db.clientes, "ID", "Nombre");
            ViewBag.Empleado_recepcion = new SelectList(db.empleados, "ID", "Nombre");
            ViewBag.Empleado_tecnico = new SelectList(db.empleados, "ID", "Nombre");
            return View();
        }

        // POST: soportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cliente,Actividad,Fecha_inicio,Fecha_Fin,Empleado_recepcion,Empleado_tecnico,Estatus")] soporte soporte)
        {
            if (ModelState.IsValid)
            {
                db.soporte.Add(soporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estatus = new SelectList(db.cEstatus, "ID", "estatus", soporte.Estatus);
            ViewBag.Cliente = new SelectList(db.clientes, "ID", "Nombre", soporte.Cliente);
            ViewBag.Empleado_recepcion = new SelectList(db.empleados, "ID", "Nombre", soporte.Empleado_recepcion);
            ViewBag.Empleado_tecnico = new SelectList(db.empleados, "ID", "Nombre", soporte.Empleado_tecnico);
            return View(soporte);
        }

        // GET: soportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            soporte soporte = db.soporte.Find(id);
            if (soporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estatus = new SelectList(db.cEstatus, "ID", "estatus", soporte.Estatus);
            ViewBag.Cliente = new SelectList(db.clientes, "ID", "Nombre", soporte.Cliente);
            ViewBag.Empleado_recepcion = new SelectList(db.empleados, "ID", "Nombre", soporte.Empleado_recepcion);
            ViewBag.Empleado_tecnico = new SelectList(db.empleados, "ID", "Nombre", soporte.Empleado_tecnico);
            return View(soporte);
        }

        // POST: soportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cliente,Actividad,Fecha_inicio,Fecha_Fin,Empleado_recepcion,Empleado_tecnico,Estatus")] soporte soporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estatus = new SelectList(db.cEstatus, "ID", "estatus", soporte.Estatus);
            ViewBag.Cliente = new SelectList(db.clientes, "ID", "Nombre", soporte.Cliente);
            ViewBag.Empleado_recepcion = new SelectList(db.empleados, "ID", "Nombre", soporte.Empleado_recepcion);
            ViewBag.Empleado_tecnico = new SelectList(db.empleados, "ID", "Nombre", soporte.Empleado_tecnico);
            return View(soporte);
        }

        // GET: soportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            soporte soporte = db.soporte.Find(id);
            if (soporte == null)
            {
                return HttpNotFound();
            }
            return View(soporte);
        }

        // POST: soportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            soporte soporte = db.soporte.Find(id);
            db.soporte.Remove(soporte);
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
