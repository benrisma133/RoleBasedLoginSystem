using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementConsole
{
    public class clsTeacher : clsRoleUser
    {
        protected override int RoleIDValue => 2;

        public static List<clsTeacher> Teachers = new List<clsTeacher>();

        public static clsTeacher FindTeacherByUserID(int userID)
        {
            return Teachers.FirstOrDefault(t => t.UserID == userID);
        }

        public override object Login(string username, string password)
        {
            return LoginAs(username, password, FindTeacherByUserID);
        }
    }

}
