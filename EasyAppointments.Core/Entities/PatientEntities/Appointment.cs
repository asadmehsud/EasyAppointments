using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.PatientEntities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int Doctor { get; set; }
        public int Patient { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;

    }
}
