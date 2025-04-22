using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.AdminEntities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ProvinceId { get; set; }
        public int Status { get; set; }
    }
}
