using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Personal.Portifolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public JsonResult Contact(string name, string email, string message)
        {
            var result = "Error";

            try
            {
                MailMessage mail = new MailMessage("dmelo.developer@gmail.com", "dmelo.developer@gmail.com");
                SmtpClient client = new SmtpClient();

                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("dmelo.developer@gmail.com", "daniel1885");

                mail.Subject = "Personal Website";
                mail.Body = "Email from:" + email + "/n Message: /n" + message;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mail);

                result = "OK";
            }
            catch (Exception)
            {
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}