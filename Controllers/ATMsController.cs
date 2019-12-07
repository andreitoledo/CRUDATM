using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDATM.Models;

namespace CRUDATM.Controllers
{
    public class ATMsController : Controller
    {
        private Context db = new Context();

        // GET: ATMs
        public ActionResult Index()
        {
            var aTMs = db.ATMs.Include(a => a.Municipios).Include(a => a.UFS);
            return View(aTMs.ToList());
        }

        // GET: ATMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATMs aTMs = db.ATMs.Find(id);
            if (aTMs == null)
            {
                return HttpNotFound();
            }
            return View(aTMs);
        }

        // GET: ATMs/Create
        public ActionResult Create()
        {
            ViewBag.MunID = new SelectList(db.Municipios, "MunID", "MunNome");
            ViewBag.UfID = new SelectList(db.UFS, "UfID", "UfSigla");
            return View();
        }

        // POST: ATMs/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtmID,AtmPC,AtmNOME,MunID,UfID")] ATMs aTMs)
        {
            if (ModelState.IsValid)
            {
                db.ATMs.Add(aTMs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MunID = new SelectList(db.Municipios, "MunID", "MunNome", aTMs.MunID);
            ViewBag.UfID = new SelectList(db.UFS, "UfID", "UfSigla", aTMs.UfID);
            return View(aTMs);
        }

        // GET: ATMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATMs aTMs = db.ATMs.Find(id);
            if (aTMs == null)
            {
                return HttpNotFound();
            }
            ViewBag.MunID = new SelectList(db.Municipios, "MunID", "MunNome", aTMs.MunID);
            ViewBag.UfID = new SelectList(db.UFS, "UfID", "UfSigla", aTMs.UfID);
            return View(aTMs);
        }

        // POST: ATMs/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtmID,AtmPC,AtmNOME,MunID,UfID")] ATMs aTMs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTMs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MunID = new SelectList(db.Municipios, "MunID", "MunNome", aTMs.MunID);
            ViewBag.UfID = new SelectList(db.UFS, "UfID", "UfSigla", aTMs.UfID);
            return View(aTMs);
        }

        // GET: ATMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATMs aTMs = db.ATMs.Find(id);
            if (aTMs == null)
            {
                return HttpNotFound();
            }
            return View(aTMs);
        }

        // POST: ATMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ATMs aTMs = db.ATMs.Find(id);
            db.ATMs.Remove(aTMs);
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
