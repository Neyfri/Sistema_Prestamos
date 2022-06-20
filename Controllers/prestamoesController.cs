using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login_Test.Models;
using Rotativa;

namespace Login_Test.Controllers
{
    public class prestamoesController : Controller
    {
        private base1Entities db = new base1Entities();

        // GET: prestamoes
        public ActionResult Index()
        {
            var prestamos = db.prestamos.Include(p => p.cliente).Include(p => p.fiador).Include(p => p.garantia1).Include(p => p.tipo_pago1);
            return View(prestamos.ToList());
        }

        // GET: prestamoes/Details/5

        /*public ActionResult Pago(int cedula,int restPago)
        {
            using (db)
            {
                prestamo prest = db.prestamos.Where(p => p.cedula == cedula).FirstOrDefault();
                var monto =prest.capital;
                long mont = Convert.ToInt64(monto);
                long resultado = mont - restPago;
                prest.capital = resultado;
                prest.periodo -= 1;

                db.Entry(prest).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                

                return View();
            }
        }*/

        public ActionResult Imprimir(int cliente=2)
        {
            return new ActionAsPdf("Details/"+cliente)
            { FileName = "Test.pdf" };
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: prestamoes/Create
        public ActionResult Create()
        {
            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula");
            ViewBag.fiador_ced = new SelectList(db.fiadors, "id", "id");
            ViewBag.garantia = new SelectList(db.garantias, "id", "nombre");
            ViewBag.tipo_pago = new SelectList(db.tipo_pago, "id", "nom_pago");
            return View();
        }

        // POST: prestamoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cedula,fecha_soli,fecha_aprob,fecha_inicio,capital,interes,fiador_ced,fecha_pago,tipo_pago,garantia,periodo")] prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.prestamos.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula", prestamo.cedula);
            ViewBag.fiador_ced = new SelectList(db.fiadors, "id", "id", prestamo.fiador_ced);
            ViewBag.garantia = new SelectList(db.garantias, "id", "nombre", prestamo.garantia);
            ViewBag.tipo_pago = new SelectList(db.tipo_pago, "id", "nom_pago", prestamo.tipo_pago);
            return View(prestamo);
        }

        // GET: prestamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula", prestamo.cedula);
            ViewBag.fiador_ced = new SelectList(db.fiadors, "id", "id", prestamo.fiador_ced);
            ViewBag.garantia = new SelectList(db.garantias, "id", "nombre", prestamo.garantia);
            ViewBag.tipo_pago = new SelectList(db.tipo_pago, "id", "nom_pago", prestamo.tipo_pago);
            return View(prestamo);
        }

        // POST: prestamoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cedula,fecha_soli,fecha_aprob,fecha_inicio,capital,interes,fiador_ced,fecha_pago,tipo_pago,garantia,periodo")] prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedula = new SelectList(db.clientes, "id", "cedula", prestamo.cedula);
            ViewBag.fiador_ced = new SelectList(db.fiadors, "id", "id", prestamo.fiador_ced);
            ViewBag.garantia = new SelectList(db.garantias, "id", "nombre", prestamo.garantia);
            ViewBag.tipo_pago = new SelectList(db.tipo_pago, "id", "nom_pago", prestamo.tipo_pago);
            return View(prestamo);
        }

        // GET: prestamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            prestamo prestamo = db.prestamos.Find(id);
            db.prestamos.Remove(prestamo);
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
