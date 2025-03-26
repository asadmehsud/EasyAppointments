namespace EasyAppointments.Services.DTOs.AdminDTOs
{
    public record AdminLoginDto
    {
        public string AdminIdentifier { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
