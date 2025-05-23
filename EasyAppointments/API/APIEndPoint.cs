﻿namespace EasyAppointments.API
{
    public class APIEndPoint
    {
        public class ProvinceEndPoint
        {
            public static string Post { get { return "Province/SaveProvince"; } }
            public static string Update { get { return "Province/UpdateProvince"; } }
            public static string Delete { get { return "Province/DeleteProvince/"; } }
            public static string GetAll { get { return "Province/GetAllProvinces"; } }
            public static string GetById { get { return "Province/GetProvinceById/"; } }
        }
        public class CityEndPoint
        {
            public static string Post { get { return "City/SaveCity"; } }
            public static string Update { get { return "City/UpdateCity"; } }
            public static string Delete { get { return "City/DeleteCity/"; } }
            public static string GetAll { get { return "City/GetAllCities"; } }
            public static string GetById { get { return "City/GetCityById/"; } }
            public static string GetCityByProvince { get { return "City/GetCityByProvince/"; } }
        }
        public class ClinicEndPoint
        {
            public static string Post { get { return "Clinic/SaveClinic"; } }
            public static string Update { get { return "Clinic/UpdateClinic"; } }
            public static string Delete { get { return "Clinic/DeleteClinic/"; } }
            public static string GetAll { get { return "Clinic/GetAllClinics"; } }
            public static string GetById { get { return "Clinic/GetClinicById/"; } }
            public static string GetClinicByCity { get { return "Clinic/GetClinicByCityId/"; } }
            public static string GetClinicDetails { get { return "Clinic/GetClinicDetails/"; } }
            public static string GetClinicByDoctor { get { return "Clinic/GetClinicByDoctor/"; } }
            public static string GetClinicByIdAndDoctor { get { return "Clinic/GetClinicByIdAndDoctor?"; } }
        }
        public class TimeEndPoint
        {
            public static string Post { get { return "Time/SaveTime"; } }
            public static string Update { get { return "Time/UpdateTime"; } }
            public static string Delete { get { return "Time/DeleteTime/"; } }
            public static string GetAll { get { return "Time/GetAllTime"; } }
            public static string GetById { get { return "Time/GetTimeById/"; } }
        }
        public class DayEndPoint
        {
            public static string Post { get { return "Day/SaveDay"; } }
            public static string Update { get { return "Day/UpdateDay"; } }
            public static string Delete { get { return "Day/DeleteDay/"; } }
            public static string GetAll { get { return "Day/GetAllDays"; } }
            public static string GetById { get { return "Day/GetDayById/"; } }
        }
        public class SpecialityEndPoint
        {
            public static string Post { get { return "Speciality/SaveSpeciality"; } }
            public static string Update { get { return "Speciality/UpdateSpeciality"; } }
            public static string Delete { get { return "Speciality/DeleteSpeciality/"; } }
            public static string GetAll { get { return "Speciality/GetAllSpecialities"; } }
            public static string GetById { get { return "Speciality/GetSpecialityById/"; } }
        }
        public class AdminEndPoint
        {
            public static string Post { get { return "Admin/SaveAdmin"; } }
            public static string Update { get { return "Admin/UpdateAdmin"; } }
            public static string Delete { get { return "Admin/DeleteAdmin/"; } }
            public static string GetAll { get { return "Admin/GetAllAdmins"; } }
            public static string GetById { get { return "Admin/GetAdminById/"; } }
        }
        public class AdminAuthenticationEndPoint
        {
            public static string Post { get { return "AdminAuthentication/Register"; } }
            public static string Login { get { return "AdminAuthentication/Login"; } }
        }
        public class DoctorRequestEndPoint
        {
            public static string ChangeStatus { get { return "DoctorRequest/ChangeStatus?UserId="; } }
            public static string GetDoctorsByStatus { get { return "DoctorRequest/GetDoctorsByStatus/"; } }
        }
        public class DoctorAuthenticationEndPoint
        {
            public static string Post { get { return "DoctorAuthentication/Register"; } }
            public static string Login { get { return "DoctorAuthentication/Login"; } }
        }
        public class DoctorEndPoint
        {
            public static string Update { get { return "Doctor/UpdateDoctor"; } }
            public static string GetAll { get { return "Doctor/GetAllDoctors"; } }
            public static string GetCityByProvince { get { return "Doctor/GetCityByProvince/"; } }
            public static string GetById { get { return "Doctor/GetDoctorById/"; } }
            public static string GetClinicByCity { get { return "Doctor/GetClinicByCity/"; } }
            public static string Delete { get { return "Doctor/Delete/"; } }
        }
        public class ScheduleEndPoint
        {
            public static string Post { get { return "Schedule/SaveSchedule"; } }
            public static string Update { get { return "Schedule/UpdateSchedule"; } }
            public static string GetScheduleDetails { get { return "Schedule/GetScheduleDetails/"; } }
            public static string GetScheduleList { get { return "Schedule/GetScheduleList/"; } }
            public static string GetById { get { return "Schedule/GetById/"; } }
            public static string GetToInsertSchedule { get { return "Schedule/GetToInsertSchedule/"; } }
            public static string DeleteSchedule { get { return "Schedule/DeleteSchedule/"; } }
        }
        public class DoctorDashboardEndPoint
        {
            public static string ChangeActiveStatus { get { return "DoctorDashboard/ChangeActiveStatus?Id="; } }
        }
        public class AppointmentEndPoint
        {
            public static string SearchDoctor { get { return "Appointment/SearchDoctor"; } }
            public static string GetAppointmentDetails { get { return "Appointment/GetAppointmentDetails?doctorId="; } }
            public static string Save { get { return "Appointment/Save "; } }
            public static string Update { get { return "Appointment/Update"; } }
        }
        public class PatientEndPoint
        {
            public static string Post { get { return "Patient/SavePatient"; } }
            public static string Update { get { return "Patient/UpdatePatient"; } }
            public static string GetAll { get { return "Patient/GetAll"; } }
            public static string GetById { get { return "Patient/GetById/"; } }
            public static string GetByIdentifier { get { return "Patient/GetByIdentifier/"; } }
            public static string Delete { get { return "Patient/Delete/"; } }
        }
        public class PatientAuthenticationEndPoint
        {
            public static string Post { get { return "PatientAuthentication/Register"; } }
            public static string Login { get { return "PatientAuthentication/Login"; } }
        }
        public class HomePageEndPoint
        {
            public static string GetData { get { return "HomePage/GetData"; } }
        }
    }
}
