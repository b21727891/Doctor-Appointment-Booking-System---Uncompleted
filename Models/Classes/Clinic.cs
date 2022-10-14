using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DoctorAppointmentBookingSys.Models.Classes
{
    public class Clinic
    {
        [Key]
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}