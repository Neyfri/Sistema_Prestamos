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
    public class inversionesController : Controller
    {
        private base1Entities db = new base1Entities();

        // GET: inversiones
        public ActionResult Index()
        {
            var inversiones = db.inversiones.Include(i => i.cliente);
            return View(inversiones.ToList());
        }

        // GET: inversiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inversione inversione = db.inversiones.Find(id);
            if (inversione == null)
            {
                return HttpNotFound();
            }
            return View(inversione);
        }

        // GET: inversiones/Create
        public ActionResult Create()
        {
            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula");
            return View();
        }

        // POST: inversiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cedula,capital,interes,fecha_inicio,fecha_pago,num_cuenta,tipo_cuenta,nom_banco,periodo")] inversione inversione)
        {
            if (ModelState.IsValid)
            {
                db.inversiones.Add(inversione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula", inversione.cedula);
            return View(inversione);
        }

        // GET: inversiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inversione inversione = db.inversiones.Find(id);
            if (inversione == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula", inversione.cedula);
            return View(inversione);
        }

        // POST: inversiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cedula,capital,interes,fecha_inicio,fecha_pago,num_cuenta,tipo_cuenta,nom_banco")] inversione inversione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inversione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula", inversione.cedula);
            return View(inversione);
        }

        // GET: inversiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inversione inversione = db.inversiones.Find(id);
            if (inversione == null)
            {
                return HttpNotFound();
            }
            return View(inversione);
        }

        // POST: inversiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inversione inversione = db.inversiones.Find(id);
            db.inversiones.Remove(inversione);
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
