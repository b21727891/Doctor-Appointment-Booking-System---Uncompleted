using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorAppointmentBookingSys.Models.Classes
{
    public class Appointment
    {
        [Key]
        public int AptID { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Complaint { get; set; }
        public bool Availability { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
    }

}