namespace WeCare_Api.Modals
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}
