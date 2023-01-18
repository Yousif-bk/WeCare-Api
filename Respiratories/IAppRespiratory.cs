using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public interface IAppRespiratory
    {
        Task<IEnumerable<Appointment>> GetAppointmentAsync();
        Task<IEnumerable<Area>> GetAreaAsync();
        Task<IEnumerable<City>> GetCityAsync();
    }
}
