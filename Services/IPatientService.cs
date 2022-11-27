using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
    }
}
