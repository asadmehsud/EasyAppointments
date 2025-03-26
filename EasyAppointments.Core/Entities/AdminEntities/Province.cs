using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.AdminEntities
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string ProvinceName { get; set; } = default!;
        public int Status { get; set; }
    }
}
