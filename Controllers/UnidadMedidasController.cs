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
    public class UnidadMedidasController : Controller
    {
        private MarketContext db = new MarketContext();

        // GET: UnidadMedidas
        public ActionResult Index()
        {
            return View(db.UnidadMedidas.ToList());
        }

        // GET: UnidadMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadMedidas unidadMedidas = db.UnidadMedidas.Find(id);
            if (unidadMedidas == null)
            {
                return HttpNotFound();
            }
            return View(unidadMedidas);
        }

        // GET: UnidadMedidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadMedidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnidadId,Codigo,Descripcion,Estado")] UnidadMedidas unidadMedidas)
        {
            if (ModelState.IsValid)
            {
                db.UnidadMedidas.Add(unidadMedidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidadMedidas);
        }

        // GET: UnidadMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadMedidas unidadMedidas = db.UnidadMedidas.Find(id);
            if (unidadMedidas == null)
            {
                return HttpNotFound();
            }
            return View(unidadMedidas);
        }

        // POST: UnidadMedidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnidadId,Codigo,Descripcion,Estado")] UnidadMedidas unidadMedidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadMedidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadMedidas);
        }

        // GET: UnidadMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadMedidas unidadMedidas = db.UnidadMedidas.Find(id);
            if (unidadMedidas == null)
            {
                return HttpNotFound();
            }
            return View(unidadMedidas);
        }

        // POST: UnidadMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadMedidas unidadMedidas = db.UnidadMedidas.Find(id);
            db.UnidadMedidas.Remove(unidadMedidas);
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
