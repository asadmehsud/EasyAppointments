namespace EasyAppointments.Services.DTOs.DoctorDTOs
{
    public record BasicDetailsDto
    {
        public int Id { get; set; }
        public string CNIC { get; set; } = default!;
        public byte[] CNICFrontImage { get; set; } = default!;
        public byte[] Image { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
    }
}
