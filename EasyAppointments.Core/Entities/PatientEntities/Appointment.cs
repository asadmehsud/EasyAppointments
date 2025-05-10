using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.PatientEntities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string? Time { get; set; }
        public string? Date { get; set; }

    }
}
