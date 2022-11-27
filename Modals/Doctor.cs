using System.ComponentModel.DataAnnotations;

namespace WeCare_Api.Modals
{
    public class Doctor
    {
        public int Id { get; set; }
        [MaxLength(55)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int Fees { get; set; }
        public string WatingTime { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
