using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Amigafa.Models;

namespace Amigafa.Controllers
{
    public class ContagemTotaisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContagemTotais
        public ActionResult Index()
        {
            return View(db.ContagemTotals.ToList());
        }

        // GET: ContagemTotais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContagemTotal contagemTotal = db.ContagemTotals.Find(id);
            if (contagemTotal == null)
            {
                return HttpNotFound();
            }
            return View(contagemTotal);
        }

        // GET: ContagemTotais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContagemTotais/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventoEncontroVeterano,EventoChurrascoVeterano,EventoCompletoVeterano,EventoEncontroConvidado,EventoChurrascoConvidado,EventoCompletoConvidado,CamisetaP,CamisetaM,CamisetaG,CamisetaGG,CamisetaXG,CamisetaXGG,Bone")] ContagemTotal contagemTotal)
        {
            if (ModelState.IsValid)
            {
                db.ContagemTotals.Add(contagemTotal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contagemTotal);
        }

        // GET: ContagemTotais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContagemTotal contagemTotal = db.ContagemTotals.Find(id);
            if (contagemTotal == null)
            {
                return HttpNotFound();
            }
            return View(contagemTotal);
        }

        // POST: ContagemTotais/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventoEncontroVeterano,EventoChurrascoVeterano,EventoCompletoVeterano,EventoEncontroConvidado,EventoChurrascoConvidado,EventoCompletoConvidado,CamisetaP,CamisetaM,CamisetaG,CamisetaGG,CamisetaXG,CamisetaXGG,Bone")] ContagemTotal contagemTotal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contagemTotal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contagemTotal);
        }

        // GET: ContagemTotais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContagemTotal contagemTotal = db.ContagemTotals.Find(id);
            if (contagemTotal == null)
            {
                return HttpNotFound();
            }
            return View(contagemTotal);
        }

        // POST: ContagemTotais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContagemTotal contagemTotal = db.ContagemTotals.Find(id);
            db.ContagemTotals.Remove(contagemTotal);
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
