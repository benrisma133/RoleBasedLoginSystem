using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementConsole
{
    public class clsUser : clsPerson
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int RoleID { get; set; }

        public static List<clsUser> Users = new List<clsUser>();

        public static clsUser LoginAsAdmin(string username, string password)
        {
            return clsUser.Users.FirstOrDefault(u =>
                u.Username == username &&
                u.Password == password &&
                u.RoleID == 3 &&
                u.IsActive);
        }

    }
}
