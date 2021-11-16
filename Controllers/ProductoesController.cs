using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Grupo7_Market.DataBase;
using Grupo7_Market.Models;

namespace Grupo7_Market.Controllers
{
    public class ProductoesController : Controller
    {
        private MarketContext db = new MarketContext();

        // GET: Productoes
        public ActionResult Index()
        {
            var productos = db.productos.Include(p => p.clasificacionProducto).Include(p => p.unidadMedidas);
            return View(productos.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.ClasificacionId = new SelectList(db.clasificacionProductos, "ClasificacionId", "Clasificacion");
            ViewBag.UnidadId = new SelectList(db.UnidadMedidas, "UnidadId", "Descripcion");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoId,Codigo,Nombre,Estado,FechaCreacion,UnidadId,ClasificacionId,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasificacionId = new SelectList(db.clasificacionProductos, "ClasificacionId", "Clasificacion", producto.ClasificacionId);
            ViewBag.UnidadId = new SelectList(db.UnidadMedidas, "UnidadId", "Descripcion", producto.UnidadId);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClasificacionId = new SelectList(db.clasificacionProductos, "ClasificacionId", "Clasificacion", producto.ClasificacionId);
            ViewBag.UnidadId = new SelectList(db.UnidadMedidas, "UnidadId", "Descripcion", producto.UnidadId);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoId,Codigo,Nombre,Estado,FechaCreacion,UnidadId,ClasificacionId,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasificacionId = new SelectList(db.clasificacionProductos, "ClasificacionId", "Clasificacion", producto.ClasificacionId);
            ViewBag.UnidadId = new SelectList(db.UnidadMedidas, "UnidadId", "Descripcion", producto.UnidadId);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.productos.Find(id);
            db.productos.Remove(producto);
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
