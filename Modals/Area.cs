namespace WeCare_Api.Modals
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Clinic> Clinics { get; set; }
    }
}
