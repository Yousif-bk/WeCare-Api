using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public interface IAppService
    {
        Task<IEnumerable<Appointment>> GetAppointmentAsync();
        Task<IEnumerable<Area>> GetAreaAsync();
        Task<IEnumerable<City>> GetCityAsync();
    }
}
