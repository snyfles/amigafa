using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Amigafa.Models;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Domain.Direct;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;
using Uol.PagSeguro.Service;

namespace Amigafa.Controllers
{
    public class ConvidadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Convidados
        public ActionResult Index()
        {
            return View(db.Convidadoes.ToList());
        }

        // GET: Convidados/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convidado convidado = db.Convidadoes.Find(id);
            if (convidado == null)
            {
                return HttpNotFound();
            }
            return View(convidado);
        }

        // GET: Convidados/Create
        public ActionResult Create(int? valortotal)
        {
            if (valortotal > 0) {

                return View();
            }

            return View();
            
        }

        // POST: Convidados/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MilitarCpf,Nome,Rg,Parentesco,Camisa,EventoEncontro,EventoChurrasco,EventoCompleto,EventoVinho")] int? valortotal, Convidado convidado)
        {   
                var userName = User.Identity.Name; //Email do militar logado no sistema;
                var query = db.Militars.Where(s => s.Email.Equals(userName)).FirstOrDefault(); //puxa cpf do usuario logado
                var mil_cpf = query.Cpf;
           
                if (valortotal > 0) { //só pra ter certeza que o valor total não está vindo vazio do evento militar
                //if (ModelState.IsValid)
                //{
                    convidado.MilitarCpf = mil_cpf;
                    db.Convidadoes.Add(convidado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                //}
                } else { return RedirectToAction("Index");    };
 
        }

        // GET: Convidados/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convidado convidado = db.Convidadoes.Find(id);
            if (convidado == null)
            {
                return HttpNotFound();
            }
            return View(convidado);
        }

        // POST: Convidados/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MilitarCpf,Nome,Rg,Parentesco,Camisa,EventoEncontro,EventoChurrasco,EventoCompleto,EventoVinho")] Convidado convidado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(convidado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(convidado);
        }

        // GET: Convidados/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convidado convidado = db.Convidadoes.Find(id);
            if (convidado == null)
            {
                return HttpNotFound();
            }
            return View(convidado);
        }

        // POST: Convidados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Convidado convidado = db.Convidadoes.Find(id);
            db.Convidadoes.Remove(convidado);
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

        public ActionResult Pagamento()
        {
            // //Use global configuration
            // PagSeguroConfiguration.UrlXmlConfiguration = "C:/Users/luis-/Desktop/amigafa/Amigafa/Configuration/PagSeguroConfig.xml";

            // bool isSandbox = true;
            // EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // // Instantiate a new payment request
            // PaymentRequest payment = new PaymentRequest();

            // // Sets the currency
            // payment.Currency = Currency.Brl;

            // // Sets a reference code for this payment request, it is useful to identify this payment in future notifications.
            // payment.Reference = "AMIGAFA" + DateTime.Now;

            // // Sets your customer information.
            // payment.Sender = new Sender(
            //     "Joao Comprador",
            //     "c93555939086072748603@sandbox.pagseguro.com.br",
            //     new Phone("11", "56273440")
            // );

            // SenderDocument document = new SenderDocument(Documents.GetDocumentByType("CPF"), "12345678909");
            // payment.Sender.Documents.Add(document);

            // // Sets the url used by PagSeguro for redirect user after ends checkout process
            // payment.RedirectUri = new Uri("http://www.lojamodelo.com.br");

            // // Add checkout metadata information
            // payment.AddMetaData(MetaDataItemKeys.GetItemKeyByDescription("CPF do passageiro"), "123.456.789-09", 1);
            // payment.AddMetaData("PASSENGER_PASSPORT", "23456", 1);


            // payment.Items.Add(new Item("0001", "Encontrao 2018", 1,250));

            // // Another way to set checkout parameters
            // payment.AddParameter("senderBirthday", "27/02/1997");
            // payment.AddIndexedParameter("itemId", "0001", 1);
            // payment.AddIndexedParameter("itemDescription", "Encontrão 2018", 1);
            // payment.AddIndexedParameter("itemQuantity", "1", 1);
            // payment.AddIndexedParameter("itemAmount", "200.00", 1);

            // // Add discount per payment method
            // // payment.AddPaymentMethodConfig(PaymentMethodConfigKeys.DiscountPercent, 0.00, PaymentMethodGroup.CreditCard);

            // // Add installment without addition per payment method
            //// payment.AddPaymentMethodConfig(PaymentMethodConfigKeys.MaxInstallmentsNoInterest, 0, PaymentMethodGroup.CreditCard);

            // // Add installment limit per payment method
            //// payment.AddPaymentMethodConfig(PaymentMethodConfigKeys.MaxInstallmentsLimit, 1, PaymentMethodGroup.CreditCard);



            // //// Add and remove groups and payment methods
            // List<string> accept = new List<string>();
            // accept.Add(ListPaymentMethodNames.DebitoItau);
            // accept.Add(ListPaymentMethodNames.DebitoHSBC);
            // payment.AcceptPaymentMethodConfig(ListPaymentMethodGroups.CreditCard, accept);

            // //List<string> exclude = new List<string>();
            // //exclude.Add(ListPaymentMethodNames.Boleto);
            // //payment.ExcludePaymentMethodConfig(ListPaymentMethodGroups.Boleto, exclude);

            // try
            // {
            //     /// Create new account credentials
            //     /// This configuration let you set your credentials from your ".cs" file.
            //     //AccountCredentials credentials = new AccountCredentials("backoffice@lojamodelo.com.br", "256422BF9E66458CA3FE41189AD1C94A");

            //     /// @todo with you want to get credentials from xml config file uncommend the line below and comment the line above.
            //     AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

            //     Uri paymentRedirectUri = payment.Register(credentials);

            //     Console.WriteLine("URL do pagamento : " + paymentRedirectUri);
            //     Console.ReadKey();
            // }
            // catch (PagSeguroServiceException exception)
            // {
            //     Console.WriteLine(exception.Message + "\n");

            //     foreach (ServiceError element in exception.Errors)
            //     {
            //         Console.WriteLine(element + "\n");
            //     }
            //     Console.ReadKey();
            // }
            PagSeguroConfiguration.UrlXmlConfiguration = "C:/Users/luis-/Desktop/amigafa/Amigafa/Configuration/PagSeguroConfig.xml";
            bool isSandbox = false;
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);

            // Instantiate a new checkout
            BoletoCheckout checkout = new BoletoCheckout();

            // Sets the payment mode
            checkout.PaymentMode = PaymentMode.DEFAULT;

            // Sets the receiver e-mail should will get paid
            checkout.ReceiverEmail = "backoffice@lojamodelo.com.br";

            // Sets the currency
            checkout.Currency = Currency.Brl;

            // Add items
            checkout.Items.Add(new Item("0001", "Notebook Prata", 2, 2000.00m));
            checkout.Items.Add(new Item("0002", "Notebook Rosa", 2, 150.99m));

            // Sets a reference code for this checkout, it is useful to identify this payment in future notifications.
            checkout.Reference = "REF1234";

            // Sets shipping information
            checkout.Shipping = new Shipping();
            checkout.Shipping.ShippingType = ShippingType.Sedex;
            checkout.Shipping.Cost = 0.00m;
            checkout.Shipping.Address = new Address(
                "BRA",
                "SP",
                "Sao Paulo",
                "Jardim Paulistano",
                "01452002",
                "Av. Brig. Faria Lima",
                "1384",
                "5o andar"
            );

            // Sets your customer information.
            // If you using SANDBOX you must use an email @sandbox.pagseguro.com.br
            checkout.Sender = new Sender(
                "Joao Comprador",
                "comprador@uol.com.br",
                new Phone("11", "56273440")
            );

            checkout.Sender.Hash = "b2806d600653cbb2b195f317ca9a1a58738187a02c05bf7f2280e2076262e73b";

            SenderDocument senderCPF = new SenderDocument(Documents.GetDocumentByType("CPF"), "12345678909");
            checkout.Sender.Documents.Add(senderCPF);

            // Sets the notification url
            checkout.NotificationURL = "http://www.lojamodelo.com.br";

            try
            {
                AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
                Transaction result = TransactionService.CreateCheckout(credentials, checkout);
                Console.WriteLine(result);
                Console.ReadKey();
            }
            catch (PagSeguroServiceException exception)
            {
                Console.WriteLine(exception.Message + "\n");
                foreach (ServiceError element in exception.Errors)
                {
                    Console.WriteLine(element + "\n");
                }
                Console.ReadKey();
            }


            return View();
        }



    }
}
