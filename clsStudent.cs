using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementConsole
{
    public class clsStudent : clsRoleUser
    {
        protected override int RoleIDValue => 1;

        public static List<clsStudent> Students = new List<clsStudent>();

        public static clsStudent FindStudentByUserID(int userID)
        {
            return Students.FirstOrDefault(s => s.UserID == userID);
        }

        public override object Login(string username, string password)
        {
            return LoginAs(username, password, FindStudentByUserID);
        }
    }

}
