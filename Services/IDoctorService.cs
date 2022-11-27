using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
    }
}
