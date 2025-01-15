using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApp
{
    public class UserStorage
    {
        public const string fileName = "Users.json";

        public User GetSignInUser()
        {
            var users = GetAllUsers();
            return users.FirstOrDefault(x => x.IsSignIn);
        }

        public void Add(User user)
        {
            var users = GetAllUsers();
            users.Add(user);
            FileProvider.Save(users, fileName);
        }

        private static List<User> GetAllUsers()
        {
            return FileProvider.Load<List<User>>(fileName) ?? new List<User>();
        }

        public void SignOut()
        {
            var signInUser = GetSignInUser();
            if (signInUser != null)
            {
                var users = GetAllUsers();
                var existsingUser = users.FirstOrDefault(x => x.Login == signInUser.Login && x.Password == signInUser.Password);
                existsingUser.IsSignIn = false;
                FileProvider.Save(users, fileName);
            }
        }
    }
}
