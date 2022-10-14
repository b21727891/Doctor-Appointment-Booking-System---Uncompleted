using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorAppointmentBookingSys.Models.Classes;
using System.Globalization;
using System.ComponentModel.DataAnnotations;


namespace DoctorAppointmentBookingSys.Controllers
{
    public class ClinicController : Controller
    {
        // GET: Clinic
        Context context = new Context();
        public ActionResult ClinicIndex()
        {
            var Values = context.Clinics.ToList();
            return View(Values);
        }
    }
}