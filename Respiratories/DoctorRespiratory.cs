using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using WeCare_Api.Dtos;
using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    
    public class DoctorRespiratory : IDoctorRespiratory
    {
        private readonly ApplicationDbContext _context;

        public DoctorRespiratory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync(DoctorSerarchDto doctorSerarchDto)
        {
            var doctors = _context.Doctors
                .Include(d => d.Clinic)
                .Include(d => d.Clinic.Area)
                .AsQueryable();

            if (!string.IsNullOrEmpty(doctorSerarchDto.DoctoreName))
            {
                doctors = doctors.Where(d => d.FullName.Contains(doctorSerarchDto.DoctoreName));
            }
            if (!string.IsNullOrEmpty(doctorSerarchDto.ClinicName))
            {
                doctors = doctors.Where(d => d.Clinic.Name.Contains(doctorSerarchDto.ClinicName));
            }
            if (!string.IsNullOrEmpty(doctorSerarchDto.Area))
            {
                doctors = doctors.Where(d => d.Clinic.Area.Name.Contains(doctorSerarchDto.Area));
            }
            var totalCount = doctors.Count();
            var results = doctors.ToPagedList(doctorSerarchDto.PageNumber, doctorSerarchDto.PageSize);
            return (results);
        }
    }
}
