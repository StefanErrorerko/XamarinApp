using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public static class AppointmentExtensions
    {

        public static Appointment Copy(this Appointment thisAppointment)
        {
            var appointment = new Appointment();
            appointment.Title = thisAppointment.Title;
            appointment.Content = thisAppointment.Content;
            appointment.Beginning = thisAppointment.Beginning;
            appointment.Ending = thisAppointment.Ending;
            return appointment;
        }
    }
}
