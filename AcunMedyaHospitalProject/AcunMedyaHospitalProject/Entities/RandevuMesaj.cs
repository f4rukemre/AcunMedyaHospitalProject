using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaHospitalProject.Entities
{
    public class RandevuMesaj
    {
        public List<Appointment> Appointments { get; set; }
        public List<Message> Messages { get; set; }
    }
}