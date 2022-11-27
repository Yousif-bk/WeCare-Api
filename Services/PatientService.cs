using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection;
using WeCare_Api.Dtos;
using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patients
                .Include(p => p.Doctor)
                .Include(p => p.Appointment)
                .Include(p => p.Doctor.Clinic)
                .Include(p => p.Doctor.Clinic.Area)
                .Include(p => p.Doctor.Clinic.Area.City)
                .ToListAsync();
        }
    }
}
