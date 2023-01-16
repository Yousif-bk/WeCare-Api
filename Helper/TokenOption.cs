namespace WeCare_Api.Helper
{
    public class TokenOption
    {
            public string Key { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public double DurationInDays { get; set; }
        }
}
