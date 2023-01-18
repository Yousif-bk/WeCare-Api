using Microsoft.EntityFrameworkCore;
using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public class AppRespiratory : IAppRespiratory
    {
        private readonly ApplicationDbContext _context;

        public AppRespiratory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentAsync()
        {
            return await _context.Appointments.
                OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<IEnumerable<Area>> GetAreaAsync()
        {
            return await _context.Areas
                .Include(a => a.City)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<City>> GetCityAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
