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
    public class fiadorsController : Controller
    {
        private base1Entities db = new base1Entities();

        // GET: fiadors
        public ActionResult Index()
        {
            var fiadors = db.fiadors.Include(f => f.cliente);
            return View(fiadors.ToList());
        }

        // GET: fiadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fiador fiador = db.fiadors.Find(id);
            if (fiador == null)
            {
                return HttpNotFound();
            }
            return View(fiador);
        }

        // GET: fiadors/Create
        public ActionResult Create()
        {
            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula");
            return View();
        }

        // POST: fiadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cedula")] fiador fiador)
        {
            if (ModelState.IsValid)
            {
                db.fiadors.Add(fiador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula", fiador.cedula);
            return View(fiador);
        }

        // GET: fiadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fiador fiador = db.fiadors.Find(id);
            if (fiador == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula", fiador.cedula);
            return View(fiador);
        }

        // POST: fiadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cedula")] fiador fiador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula", fiador.cedula);
            return View(fiador);
        }

        // GET: fiadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fiador fiador = db.fiadors.Find(id);
            if (fiador == null)
            {
                return HttpNotFound();
            }
            return View(fiador);
        }

        // POST: fiadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fiador fiador = db.fiadors.Find(id);
            db.fiadors.Remove(fiador);
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
