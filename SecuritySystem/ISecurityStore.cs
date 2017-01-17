using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritySystem
{
    public interface ISecurityStore
    {
        ISecurityUser GetUserByUsername(string username);
        void RegisterUser(ISecurityUser user);
    }
}
