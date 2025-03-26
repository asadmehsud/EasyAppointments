namespace EasyAppointments.Services.DTOs.PatientDTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Time { get; set; } = default!;
        public string Date { get; set; } = default!;
        public string PatientName { get; set; } = default!;
        public string DocotorName { get; set; } = default!;

    }
}
