using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritySystem
{
    public class SecurityUser : ISecurityUser
    {
        private string _password;
        private string _username;
        private List<IRole> _roles;


        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public List<IRole> Roles
        {
            get
            {
                return _roles;
            }

            set
            {
                _roles = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public bool ContainsRole(string roleName)
        {
            if (_roles == null)
                return false;

            return _roles.Exists(a => a.Name.Equals(roleName));
        }
    }
}
