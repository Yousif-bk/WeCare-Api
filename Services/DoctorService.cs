using Microsoft.EntityFrameworkCore;
using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext context)
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
