namespace WeCare_Api.Contracts
{
    public class ApiRoute
    {
        public static class Account
        {
            public const string Login = "api/account/login";
            public const string Create = "api/account/create";
        }

        public class Master
        {
            public const string Appointment = "api/master/Appointment";
            public const string Area = "api/master/Area";
            public const string City = "api/master/Cities";
        }
        public class Doctor
        {
            public const string GetDoctors = "api/doctor/search";
        }
        public class Patient
        {
            public const string GetPatients = "api/patient/search";
        }
    }
}
