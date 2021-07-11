
namespace auth_api.Entities
{
    public class UserEntity 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string pwhash { get; set; }
        public string email { get; set; }
    }
}