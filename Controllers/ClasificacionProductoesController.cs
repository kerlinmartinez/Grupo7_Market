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
    public class ClasificacionProductoesController : Controller
    {
        private MarketContext db = new MarketContext();

        // GET: ClasificacionProductoes
        public ActionResult Index()
        {
            return View(db.clasificacionProductos.ToList());
        }

        // GET: ClasificacionProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasificacionProducto clasificacionProducto = db.clasificacionProductos.Find(id);
            if (clasificacionProducto == null)
            {
                return HttpNotFound();
            }
            return View(clasificacionProducto);
        }

        // GET: ClasificacionProductoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClasificacionProductoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClasificacionId,Codigo,Clasificacion,Estado")] ClasificacionProducto clasificacionProducto)
        {
            if (ModelState.IsValid)
            {
                db.clasificacionProductos.Add(clasificacionProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clasificacionProducto);
        }

        // GET: ClasificacionProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasificacionProducto clasificacionProducto = db.clasificacionProductos.Find(id);
            if (clasificacionProducto == null)
            {
                return HttpNotFound();
            }
            return View(clasificacionProducto);
        }

        // POST: ClasificacionProductoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClasificacionId,Codigo,Clasificacion,Estado")] ClasificacionProducto clasificacionProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clasificacionProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clasificacionProducto);
        }

        // GET: ClasificacionProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasificacionProducto clasificacionProducto = db.clasificacionProductos.Find(id);
            if (clasificacionProducto == null)
            {
                return HttpNotFound();
            }
            return View(clasificacionProducto);
        }

        // POST: ClasificacionProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClasificacionProducto clasificacionProducto = db.clasificacionProductos.Find(id);
            db.clasificacionProductos.Remove(clasificacionProducto);
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
