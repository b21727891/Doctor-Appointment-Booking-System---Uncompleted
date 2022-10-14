using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DoctorAppointmentBookingSys.Models.Classes
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public Clinic Clinic { get; set; }
        public int ClinicID { get; set; }
        public DateTime AptHours { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}