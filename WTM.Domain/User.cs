namespace WTM.Domain
{
    public class User : BaseClass
    {
        public User(string Username)
        {
            this.Username = Username;
        }

        public string Username { get; set; }
    }
}
