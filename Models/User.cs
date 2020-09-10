namespace FCA_Login_WebApi.Models
{
    public class User
    {   
        public int id { get; set; }
        public bool user_inactive { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string user_register { get; set; }
        public string user_num_emp { get; set; }
        public string user_cresp { get; set; }
    }
}