using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public interface IPatientRespiratory
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
    }
}
