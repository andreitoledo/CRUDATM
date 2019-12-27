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
    public class UFSController : Controller
    {
        private Context db = new Context();

        // GET: UFS
        public ActionResult Index()
        {
            return View(db.UFS.ToList());
        }

        // validação para não deixar repetir o atributo UfNome
        public JsonResult ValidaNome(string UfNome) {
            return Json(!db.UFS.Any(x => x.UfNome == UfNome), JsonRequestBehavior.AllowGet);
        }

        // GET: UFS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UFS uFS = db.UFS.Find(id);
            if (uFS == null)
            {
                return HttpNotFound();
            }
            return View(uFS);
        }

        // GET: UFS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UFS/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UfID,UfSigla,UfNome")] UFS uFS)
        {
            if (ModelState.IsValid)
            {
                db.UFS.Add(uFS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uFS);
        }

        // GET: UFS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UFS uFS = db.UFS.Find(id);
            if (uFS == null)
            {
                return HttpNotFound();
            }
            return View(uFS);
        }

        // POST: UFS/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UfID,UfSigla,UfNome")] UFS uFS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uFS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uFS);
        }

        // GET: UFS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UFS uFS = db.UFS.Find(id);
            if (uFS == null)
            {
                return HttpNotFound();
            }
            return View(uFS);
        }

        // POST: UFS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UFS uFS = db.UFS.Find(id);
            db.UFS.Remove(uFS);
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
