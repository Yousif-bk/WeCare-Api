using AutoMapper;
using WeCare_Api.Dtos;
using WeCare_Api.Modals;

namespace WeCare_Api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<Clinic, ClinicDto>();
            CreateMap<Area, AreaDto>();
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<City, CityDto>();
        }
    }
}
