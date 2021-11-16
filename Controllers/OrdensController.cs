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
    public class OrdensController : Controller
    {
        private MarketContext db = new MarketContext();

        // GET: Ordens
        public ActionResult Index()
        {
            var ordens = db.ordens.Include(o => o.clientes);
            return View(ordens.ToList());
        }

        // GET: Ordens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // GET: Ordens/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteId", "NombreCliente");
            return View();
        }

        // POST: Ordens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdenId,FechaCreacion,ClienteID")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.ordens.Add(orden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteId", "NombreCliente", orden.ClienteID);
            return View(orden);
        }

        // GET: Ordens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteId", "NombreCliente", orden.ClienteID);
            return View(orden);
        }

        // POST: Ordens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdenId,FechaCreacion,ClienteID")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteId", "NombreCliente", orden.ClienteID);
            return View(orden);
        }

        // GET: Ordens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden orden = db.ordens.Find(id);
            db.ordens.Remove(orden);
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
