using Send_Email.Database;
using Send_Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using Web.Deploy;
using Web.Deploy.Views.Layout;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    { 
        public string Test(EmailTable em)
        { 
            var output = "";
            try
            {
                output = (new EmailModel()).sendEmail(em);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }


            return output;
        }
        public string Add(EmailTable em)
        {
            try
            {
                var id = (new Sqlbase<EmailTable>().Read()).Count() + 1;
                new Sqlbase<EmailTable>().Create((new JC<EmailTable>()).ToJson(em));
            }
            catch { }

            return "done";
        }
        public string Remove(EmailTable em)
        {
            try
            {
                new Sqlbase<EmailTable>().Delete(em.Idx);
            }
            catch { }

            return "done";
        }
        public string Clear()
        {
            try
            {
                new Sqlbase<EmailTable>().DeleteAll();
            }
            catch { }

            return "done";
        }
        public string Receive()
        {
            var result = new List<EmailTable>();

            try
            {
                result = new Sqlbase<EmailTable>().Read();
            }
            catch { } 

            return new JC<EmailTable>().ToJsonArr(result);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}