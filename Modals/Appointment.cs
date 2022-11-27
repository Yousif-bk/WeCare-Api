namespace WeCare_Api.Modals
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DayOfWeek { get; set; }
        public string Reservation { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public Patient Patient { get; set; }
    }
}
