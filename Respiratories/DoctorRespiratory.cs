using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _context.Doctors
                .Include(d => d.Clinic)
                .Include(d => d.Clinic.Area)
                .Include(d => d.Appointments)
                .ToListAsync();
        }
    }
}
