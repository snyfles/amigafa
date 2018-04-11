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
    public class Militar_EventoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Militar_Evento
        public ActionResult Index()
        {
            return View(db.Militar_Evento.ToList());
        }

        // GET: Militar_Evento/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Militar_Evento militar_Evento = db.Militar_Evento.Find(id);
            if (militar_Evento == null)
            {
                return HttpNotFound();
            }
            return View(militar_Evento);
        }

        // GET: Militar_Evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Militar_Evento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Camiseta,EventoEncontro,EventoChurrasco,EventoCompleto,EventoVinho")] Militar_Evento militar_Evento)
        {
            int valortotal = 10;   
      
            
                //if (ModelState.IsValid)
                //{

                    var userName = User.Identity.Name; //Email do militar logado no sistema;
                    var query = db.Militars.Where(s => s.Email.Equals(userName)).FirstOrDefault(); //puxa cpf do usuario logado;
                    var mil_cpf = query.Cpf; //adiciona o cpf na var;

                    militar_Evento.Militar_Cpf = mil_cpf;
                    db.Militar_Evento.Add(militar_Evento);
                    db.SaveChanges();
                    return RedirectToAction("Create", "Convidados", new { ValorTotal = valortotal }); 
                //}
            


            return View(militar_Evento);
        }

        // GET: Militar_Evento/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Militar_Evento militar_Evento = db.Militar_Evento.Find(id);
            if (militar_Evento == null)
            {
                return HttpNotFound();
            }
            return View(militar_Evento);
        }

        // POST: Militar_Evento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Militar_Cpf,Camiseta,EventoEncontro,EventoChurrasco,EventoCompleto,EventoVinho")] Militar_Evento militar_Evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(militar_Evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(militar_Evento);
        }

        // GET: Militar_Evento/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Militar_Evento militar_Evento = db.Militar_Evento.Find(id);
            if (militar_Evento == null)
            {
                return HttpNotFound();
            }
            return View(militar_Evento);
        }

        // POST: Militar_Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Militar_Evento militar_Evento = db.Militar_Evento.Find(id);
            db.Militar_Evento.Remove(militar_Evento);
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
