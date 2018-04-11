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
    public class PagamentosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pagamentos
        public ActionResult Index()
        {
            return View(db.Pagamentos.ToList());
        }

        // GET: Pagamentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pagamentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Cpf,Email,Status,ValorPagamento,DataPagamento")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                db.Pagamentos.Add(pagamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pagamentos);
        }

        // GET: Pagamentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos);
        }

        // POST: Pagamentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nome,Cpf,Email,Status,ValorPagamento,DataPagamento")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pagamentos);
        }

        // GET: Pagamentos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            if (pagamentos == null)
            {
                return HttpNotFound();
            }
            return View(pagamentos);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pagamentos pagamentos = db.Pagamentos.Find(id);
            db.Pagamentos.Remove(pagamentos);
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
