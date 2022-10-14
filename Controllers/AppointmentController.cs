using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorAppointmentBookingSys.Models.Classes;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
namespace DoctorAppointmentBookingSys.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        Context context = new Context();

        public static void Email(string htmlString, string emailAdress) //Notification e-mail sending mechanism.
        {

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("oguzyurtcu44@gmail.com");
                message.To.Add(new MailAddress(emailAdress));
                message.Subject = "Klinik randevunuz hk.";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString; //content of the mail
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("oguzyurtcu44@gmail.com", "uksfogsiouikuqdo");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {

            }
        }

        public ActionResult AppointmentIndex()
        {
            var Values = context.AppointmentsUI.ToList();
            return View(Values);
        }
        [HttpGet]
        public ActionResult BookApt()
        {
            ViewData["Doctors"] = new List<SelectListItem> {
                     new SelectListItem {
                        Text="Kaya Avşar",
                        Value="1",
                        // Selected = true, seçili olarak gelsin
                        // Disabled = true  disable olarak gelsin istersek kullanıyoruz
                     },
                     new SelectListItem {
                        Text="Mehmet Öz",
                        Value="2",
                     },
                 };
            return View();
        }
        [HttpPost]
        public ActionResult BookApt(Appointment k)
        {
            context.Appointments.Add(k);
            context.SaveChanges();
            var user = context.Users.Where(p => p.UserID == k.UserID).FirstOrDefault();
            Email("Randevunuz oluşturulmuştur, sağlıklı günler dileriz.", user.UserMail);
            return RedirectToAction("AppointmentIndex");
        }

        public ActionResult CancelApt(int AptID)
        {
            var apt = context.Appointments.Find(AptID);
            context.Appointments.Remove(apt);
            context.SaveChanges();
            return RedirectToAction("AppointmentIndex");
        }
        public ActionResult BringApt(int AptID)
        {
            var appointment = context.Appointments.Find(AptID);
            return View("BringApt", appointment);
        }

    }
}