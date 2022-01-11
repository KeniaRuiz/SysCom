using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SysCom.Models;

namespace SysCom.Controllers
{
    public class recepcionsController : Controller
    {
        private bdsyscomEntities db = new bdsyscomEntities();
        // GET: recepcions
        public ActionResult Index(string busqueda, int? ListaEstatus)
        {
            var recepcion = db.recepcion.Include(r => r.cEstatus).Include(r => r.clientes).Include(r => r.empleados).Include(r => r.empleados1);


            if (!String.IsNullOrEmpty(busqueda))
            {
                recepcion = recepcion.Where(s => s.Problema.Contains(busqueda));
            }

            if (ListaEstatus != null)
            {
                recepcion = recepcion.Where(s => s.Estatus ==ListaEstatus );
            }

            ViewBag.Mensaje = ListaEstatus;

            return View(recepcion.ToList());
        
        }

        public ActionResult ConvertirImagen(int? ID)
        {
            var imagen = db.recepcion.Where(x => x.ID == ID).FirstOrDefault();
            if(imagen.imagen != null){
                return File(imagen.imagen, "image/jpeg");
            }
            else
            {
                return null;
            }
        }

        // GET: recepcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recepcion recepcion = db.recepcion.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            return View(recepcion);
        }

        // GET: recepcions/Create
        public ActionResult Create()
        {
            ViewBag.Estatus = new SelectList(db.cEstatus, "ID", "estatus");
            ViewBag.Cliente = new SelectList(db.clientes, "ID", "Nombre");
            ViewBag.Empleado_recepcion = new SelectList(db.empleados, "ID", "Nombre");
            ViewBag.Empleado_tecnico = new SelectList(db.empleados, "ID", "Nombre");
            return View();
        }

        // POST: recepcions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cliente,Problema,Equipo,Fecha_inicio,Fecha_fin,Empleado_recepcion,Empleado_tecnico,Estatus")] recepcion recepcion, HttpPostedFileBase imagen)
        {
            if(imagen != null && imagen.ContentLength>0)
            {
                byte[] imagenData = null;

                using (var binaryImagen = new BinaryReader (imagen.InputStream))
                {
                    imagenData = binaryImagen.ReadBytes(imagen.ContentLength);
                }
                recepcion.imagen = imagenData;
            }

            if (ModelState.IsValid)
            {
                db.recepcion.Add(recepcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estatus = new SelectList(db.cEstatus, "ID", "estatus", recepcion.Estatus);
            ViewBag.Cliente = new SelectList(db.clientes, "ID", "Nombre", recepcion.Cliente);
            ViewBag.Empleado_recepcion = new SelectList(db.empleados, "ID", "Nombre", recepcion.Empleado_recepcion);
            ViewBag.Empleado_tecnico = new SelectList(db.empleados, "ID", "Nombre", recepcion.Empleado_tecnico);
            return View(recepcion);
        }

        // GET: recepcions/Edit/5
        
        public ActionResult Edit(int? id)
        {
            var imagenA = db.recepcion.Where(x => x.ID == id).FirstOrDefault();
            TempData["imagenActual"] = imagenA.imagen;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recepcion recepcion = db.recepcion.Find(id);

            if (recepcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estatus = new SelectList(db.cEstatus, "ID", "estatus", recepcion.Estatus);
            ViewBag.Cliente = new SelectList(db.clientes, "ID", "Nombre", recepcion.Cliente);
            ViewBag.Empleado_recepcion = new SelectList(db.empleados, "ID", "Nombre", recepcion.Empleado_recepcion);
            ViewBag.Empleado_tecnico = new SelectList(db.empleados, "ID", "Nombre", recepcion.Empleado_tecnico);
            return View(recepcion);

            
    }

        // POST: recepcions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cliente,Problema,Equipo,Fecha_inicio,Fecha_fin,Empleado_recepcion,Empleado_tecnico,Estatus")] recepcion recepcion, HttpPostedFileBase imagen)
        {

            if (imagen != null && imagen.ContentLength > 0)
            {
                byte[] imagenData = null;

                using (var binaryImagen = new BinaryReader(imagen.InputStream))
                {
                    imagenData = binaryImagen.ReadBytes(imagen.ContentLength);
                }
                recepcion.imagen = imagenData;
            }
            else
            {
                //Se quede con la misma imagen
                byte[] imagenAct = TempData["imagenActual"] as byte[];
                recepcion.imagen = imagenAct;

            }

            if (ModelState.IsValid)
            {
                db.Entry(recepcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estatus = new SelectList(db.cEstatus, "ID", "estatus", recepcion.Estatus);
            ViewBag.Cliente = new SelectList(db.clientes, "ID", "Nombre", recepcion.Cliente);
            ViewBag.Empleado_recepcion = new SelectList(db.empleados, "ID", "Nombre", recepcion.Empleado_recepcion);
            ViewBag.Empleado_tecnico = new SelectList(db.empleados, "ID", "Nombre", recepcion.Empleado_tecnico);
            return View(recepcion);
        }

        // GET: recepcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recepcion recepcion = db.recepcion.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            return View(recepcion);
        }

        // POST: recepcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recepcion recepcion = db.recepcion.Find(id);
            db.recepcion.Remove(recepcion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
