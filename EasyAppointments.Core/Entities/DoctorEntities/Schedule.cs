namespace EasyAppointments.Data.Entities.DoctorEntities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public int DayId { get; set; }
        public int TimeId { get; set; }
        public int AppointmentFee { get; set; }
    }
}
