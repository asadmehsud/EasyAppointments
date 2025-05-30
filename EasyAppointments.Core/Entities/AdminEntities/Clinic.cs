﻿using System.ComponentModel.DataAnnotations;

namespace EasyAppointments.Data.Entities.AdminEntities
{
    public class Clinic
    {
        [Key]
        public int Id { get; set; }
        public string? ClinicName { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string? Address { get; set; }
        public int DoctorId { get; set; }

    }
}
