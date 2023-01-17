using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WeCare_Api.Modals
{
    public class ApplicationUsers : IdentityUser
    {
        [MaxLength(55)]
        public string FirstName { get; set; }
        [MaxLength(55)]
        public string LastName { get; set; }
    }
}
