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
    public class MilitarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Militar
        public ActionResult Index()
        {
            return View(db.Militars.ToList());
        }

        // GET: Militar/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Militar militar = db.Militars.Find(id);
            if (militar == null)
            {
                return HttpNotFound();
            }
            return View(militar);
        }

        // GET: Militar/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;

                var query = db.Militars.Where(s => s.Email.Equals(userName)).FirstOrDefault();
                //var usuario = query.Email;

                if (query != null && query.Email.Equals(userName))
                {
                    return RedirectToAction("Create", "Militar_Evento");
                }
                else
                {
                    return View();
                }
            }
                
                return View();
        }

        // POST: Militar/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cpf,RgCivil,RgMilitar,Nome,NomeGuerra,PostoGrad,DataFormatura,Cep,Endereco,NumeroEndereco,ComplementoEndereco,Bairro,Cidade,Estado,Telefone,Celular")] Militar militar)
        {
            var userName = User.Identity.Name;
            //if (ModelState.IsValid)
            //{
                militar.Email = userName;
                db.Militars.Add(militar);
                db.SaveChanges();
                return RedirectToAction("Create", "Militar_Evento"); // aqui vai redirecionar para o pagamento dos pacotes
            //}           
   
        }

        // GET: Militar/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Militar militar = db.Militars.Find(id);
            if (militar == null)
            {
                return HttpNotFound();
            }
            return View(militar);
        }

        // POST: Militar/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cpf,RgCivil,RgMilitar,Nome,NomeGuerra,PostoGrad,DataFormatura,Cep,Endereco,NumeroEndereco,ComplementoEndereco,Bairro,Cidade,Estado,Telefone,Celular,Email")] Militar militar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(militar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(militar);
        }

        // GET: Militar/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Militar militar = db.Militars.Find(id);
            if (militar == null)
            {
                return HttpNotFound();
            }
            return View(militar);
        }

        // POST: Militar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Militar militar = db.Militars.Find(id);
            db.Militars.Remove(militar);
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
