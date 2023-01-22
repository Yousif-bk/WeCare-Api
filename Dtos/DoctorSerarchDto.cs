namespace WeCare_Api.Dtos
{
    public class DoctorSerarchDto
    {
        public string DoctoreName { get; set; }
        public string ClinicName { get; set; }
        public string Appointments { get; set; }
        public string Area { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
