using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public interface IDoctorRespiratory
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
    }
}
