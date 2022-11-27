namespace WeCare_Api.Modals
{
    public class Patient
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
        public int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
