using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login_Test.Models;

namespace Login_Test.Controllers
{
    public class garantiasController : Controller
    {
        private base1Entities db = new base1Entities();

        // GET: garantias
        public ActionResult Index()
        {
            var garantias = db.garantias.Include(g => g.tipo_garantia);
            return View(garantias.ToList());
        }

        // GET: garantias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garantia garantia = db.garantias.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            return View(garantia);
        }

        // GET: garantias/Create
        public ActionResult Create()
        {
            ViewBag.tipo = new SelectList(db.tipo_garantia, "id", "tipo");
            return View();
        }

        // POST: garantias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,tipo,valor,ubicacion")] garantia garantia)
        {
            if (ModelState.IsValid)
            {
                db.garantias.Add(garantia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipo = new SelectList(db.tipo_garantia, "id", "tipo", garantia.tipo);
            return View(garantia);
        }

        // GET: garantias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garantia garantia = db.garantias.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo = new SelectList(db.tipo_garantia, "id", "tipo", garantia.tipo);
            return View(garantia);
        }

        // POST: garantias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,tipo,valor,ubicacion")] garantia garantia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garantia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipo = new SelectList(db.tipo_garantia, "id", "tipo", garantia.tipo);
            return View(garantia);
        }

        // GET: garantias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garantia garantia = db.garantias.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            return View(garantia);
        }

        // POST: garantias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            garantia garantia = db.garantias.Find(id);
            db.garantias.Remove(garantia);
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
