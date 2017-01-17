using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritySystem
{
    public interface ISecurityManager
    {

        ISecurityUser CurrentUser { get; }

        void Initialize(ISecurityStore store);

        LoginResult Login(string username, string password);

        bool Authorize(string roleName);

        bool ValidatePassword(ISecurityUser user, string passwordToValidate);

        string CryptoPassword(string password);

        void RegisterUser(ISecurityUser user);
    }
}
