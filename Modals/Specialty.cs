namespace WeCare_Api.Modals
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Clinic> Clinics { get; set; }
    }
}
