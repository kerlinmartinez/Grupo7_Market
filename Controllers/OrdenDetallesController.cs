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
    public class OrdenDetallesController : Controller
    {
        private MarketContext db = new MarketContext();

        // GET: OrdenDetalles
        public ActionResult Index()
        {
            var ordenDetalles = db.ordenDetalles.Include(o => o.Orden).Include(o => o.producto);
            return View(ordenDetalles.ToList());
        }

        // GET: OrdenDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDetalle ordenDetalle = db.ordenDetalles.Find(id);
            if (ordenDetalle == null)
            {
                return HttpNotFound();
            }
            return View(ordenDetalle);
        }

        // GET: OrdenDetalles/Create
        public ActionResult Create()
        {
            ViewBag.OrdenId = new SelectList(db.ordens, "OrdenId", "OrdenId");
            ViewBag.ProductoId = new SelectList(db.productos, "ProductoId", "Nombre");
            return View();
        }

        // POST: OrdenDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetalleId,OrdenId,ProductoId,Precio,Cantidad,Descuento,Total")] OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                db.ordenDetalles.Add(ordenDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrdenId = new SelectList(db.ordens, "OrdenId", "OrdenId", ordenDetalle.OrdenId);
            ViewBag.ProductoId = new SelectList(db.productos, "ProductoId", "Nombre", ordenDetalle.ProductoId);
            return View(ordenDetalle);
        }

        // GET: OrdenDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDetalle ordenDetalle = db.ordenDetalles.Find(id);
            if (ordenDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrdenId = new SelectList(db.ordens, "OrdenId", "OrdenId", ordenDetalle.OrdenId);
            ViewBag.ProductoId = new SelectList(db.productos, "ProductoId", "Nombre", ordenDetalle.ProductoId);
            return View(ordenDetalle);
        }

        // POST: OrdenDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetalleId,OrdenId,ProductoId,Precio,Cantidad,Descuento,Total")] OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrdenId = new SelectList(db.ordens, "OrdenId", "OrdenId", ordenDetalle.OrdenId);
            ViewBag.ProductoId = new SelectList(db.productos, "ProductoId", "Nombre", ordenDetalle.ProductoId);
            return View(ordenDetalle);
        }

        // GET: OrdenDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDetalle ordenDetalle = db.ordenDetalles.Find(id);
            if (ordenDetalle == null)
            {
                return HttpNotFound();
            }
            return View(ordenDetalle);
        }

        // POST: OrdenDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenDetalle ordenDetalle = db.ordenDetalles.Find(id);
            db.ordenDetalles.Remove(ordenDetalle);
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
