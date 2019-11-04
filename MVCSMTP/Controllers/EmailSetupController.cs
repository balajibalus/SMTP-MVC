using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSMTP.Models;
using System.Net;
using System.Net.Mail;

namespace MVCSMTP.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MVCSMTP.Models.Gmail model)
        {
            MailMessage mm = new MailMessage("balaji.sandupatla@gmail.com", model.To)
            {
                Subject = model.Subject,
                Body = model.Body,
                IsBodyHtml = false
            };

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true
            };

            NetworkCredential nc = new NetworkCredential("balaji.sandupatla@gmail.com", "balaji@paru");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail Has Been Sent Successfully!";


            return View();
        }
    }
}