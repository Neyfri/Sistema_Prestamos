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
    public class pagosController : Controller
    {
        private base1Entities db = new base1Entities();

        // GET: pagos
        public ActionResult Index()
        {
            var pagos = db.pagos.Include(p => p.prestamo).Include(p => p.tipo_pago);
            return View(pagos.ToList());
        }

        // GET: pagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pago pago = db.pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: pagos/Create
        public ActionResult Create()
        {
            ViewBag.cod_prestamo = new SelectList(db.prestamos, "id", "id");
            ViewBag.modalida_pago = new SelectList(db.tipo_pago, "id", "nom_pago");
            return View();
        }

        public ActionResult Pagar()
        {
            return View("Pagar");
        }

        public ActionResult Pago(int cod_prestamo,long monto_pago)
        {
            using (db)
            {
                prestamo variable = db.prestamos.Where(x => x.id == cod_prestamo).FirstOrDefault();
                variable.capital = variable.capital - monto_pago;
                variable.periodo -= 1;
                db.SaveChanges();
            }
            return View("Index");
        }

        // POST: pagos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cod_prestamo,monto_pago,modalida_pago")] pago pago)
        {
            if (ModelState.IsValid)
            {
                db.pagos.Add(pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_prestamo = new SelectList(db.prestamos, "id", "id", pago.cod_prestamo);
            ViewBag.modalida_pago = new SelectList(db.tipo_pago, "id", "nom_pago", pago.modalida_pago);
            return View(pago);
        }

        // GET: pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pago pago = db.pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_prestamo = new SelectList(db.prestamos, "id", "id", pago.cod_prestamo);
            ViewBag.modalida_pago = new SelectList(db.tipo_pago, "id", "nom_pago", pago.modalida_pago);
            return View(pago);
        }

        // POST: pagos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cod_prestamo,monto_pago,modalida_pago")] pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_prestamo = new SelectList(db.prestamos, "id", "id", pago.cod_prestamo);
            ViewBag.modalida_pago = new SelectList(db.tipo_pago, "id", "nom_pago", pago.modalida_pago);
            return View(pago);
        }

        // GET: pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pago pago = db.pagos.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pago pago = db.pagos.Find(id);
            db.pagos.Remove(pago);
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
