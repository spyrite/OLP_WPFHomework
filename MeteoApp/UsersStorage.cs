using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApp
{

    public static class UsersStorage
    {
        private static List<User> users = [];

        public static void Add(User user)
        {
            users.Add(user);
        }
    }
}
