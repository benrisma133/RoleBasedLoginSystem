using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementConsole
{
    public interface ILogin
    {
        object Login(string username, string password);
    }

}
