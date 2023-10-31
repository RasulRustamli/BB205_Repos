using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_205_Single
{
    internal class UserCRUD
    {
        public void UserAdd(User user)
        {
            if (user != null)
            {
                DataBase.Users.Add(user);
            }

        }
        public void Delete(string username)
        {
            User user = DataBase.Users.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());
            if (user != null)
            {
                DataBase.Users.Remove(user);
            }
        }
    }
}
