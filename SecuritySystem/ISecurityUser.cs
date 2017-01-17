using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritySystem
{
    public interface ISecurityUser
    {
        string Username { get; set; }
        string Password { get; set; }
        List<IRole> Roles { get; set; }

        bool ContainsRole(string roleName);


    }
}
