using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DoctorAppointmentBookingSys.Models.Classes
{
    public class Feedback
    {
        [Key]
        public int UserID { get; set; }
        public string Title { get; set; }
        public string FeedBack { get; set; }
        public DateTime Time { get; set; }
    }
}