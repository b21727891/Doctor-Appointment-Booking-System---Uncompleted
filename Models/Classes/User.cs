using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DoctorAppointmentBookingSys.Models.Classes
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public decimal? ParkCost { get; set; }
        public string UserMail { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection <Feedback> Feedbacks { get; set; }
    }
}