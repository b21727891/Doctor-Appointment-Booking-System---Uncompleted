using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointmentBookingSys.Models.Classes
{
    //For database view AptCalendarsUI
    public partial class AptCalendarsUI
    {
        public int AptID { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorID { get; set; }
        public string Complaint { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public string DoctorName { get; set; }
        public string UserName { get; set; }
    }
}