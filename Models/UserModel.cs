namespace Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserModel() { }
        public UserModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
