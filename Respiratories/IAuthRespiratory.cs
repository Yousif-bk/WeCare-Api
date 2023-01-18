using WeCare_Api.Modals;

namespace WeCare_Api.Services
{
    public interface IAuthRespiratory
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}
