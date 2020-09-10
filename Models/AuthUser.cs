namespace FCA_Login_WebApi.Models
{
    public class AuthUser
    {   
        public int id { get; set; }
        public string user_name { get; set; }
        public string pushId { get; set; }
        public bool admin { get; set; }
        public string jwtExpirationTimeInSecconds { get; set; }
        public string systemIDByUserType { get; set; }
    }
}