using WeCare_Api.Modals;

namespace WeCare_Api.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string FullName { get; set; } = String.Empty;
        public string? Status { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = String.Empty;
        public string? Email { get; set; }
        public string Phone { get; set; } = String.Empty;
        public AppointmentDto? Appointment { get; set; }
        public DoctorDto? Doctor { get; set; }

    }
}
