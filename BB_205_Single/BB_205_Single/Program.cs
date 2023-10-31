namespace BB_205_Single
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            string username = "blackman";
            string password = "white2004";

            if(user.UserNameCheck(username))
            {
                user.UserName = username;
                user.Password = password;
            }
            user.UserAdd(user);
            user.Delete("asdas");
            
        }
    }
}