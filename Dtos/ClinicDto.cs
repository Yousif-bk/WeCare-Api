using WeCare_Api.Modals;

namespace WeCare_Api.Dtos
{
    public class ClinicDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public AreaDto? Area { get; set; }
    }
}
