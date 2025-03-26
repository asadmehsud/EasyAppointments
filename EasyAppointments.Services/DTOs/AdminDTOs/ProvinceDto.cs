using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Services.DTOs.AdminDTOs
{
    public class ProvinceDto
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ProvinceName { get; set; } = default!;
        //[Required(ErrorMessage = "Select Status")]
        ////[Range(0, int.MaxValue)]
        public int Status { get; set; }
    }
}
