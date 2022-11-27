namespace WeCare_Api.Modals
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public ICollection<Specialty> Specialties { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
    }
}
