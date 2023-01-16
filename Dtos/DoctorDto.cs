using System.ComponentModel.DataAnnotations;
using WeCare_Api.Modals;

namespace WeCare_Api.Dtos
{
    public class DoctorDto: BaseResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string FullName { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public int Fees { get; set; }
        public string WatingTime { get; set; } = String.Empty; 
        public ClinicDto? Clinic { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; } 
    }
}
