using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementConsole
{
    public abstract class clsRoleUser : clsUser, ILogin
    {
        protected abstract int RoleIDValue { get; }

        protected T LoginAs<T>(string username, string password,
                               Func<int, T> findByUserID)
        {
            var user = clsUser.Users
                .FirstOrDefault(u =>
                    u.Username == username &&
                    u.Password == password &&
                    u.RoleID == RoleIDValue &&
                    u.IsActive);

            if (user == null)
                return default(T);

            return findByUserID(user.UserID);
        }

        public abstract object Login(string username, string password);
    }

}
