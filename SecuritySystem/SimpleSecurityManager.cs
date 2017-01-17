using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuritySystem
{
    public class SimpleSecurityManager : ISecurityManager
    {

        private static SimpleSecurityManager _instance;

        public static SimpleSecurityManager Instance()
        {
            if (_instance == null)
                _instance = new SimpleSecurityManager();
            return _instance;
        }

        private SimpleSecurityManager()
        {

        }

        private bool _initialized = false;
        private ISecurityStore _store;
        private ISecurityUser _currentUser;

        private void CheckInitializzation()
        {
            if (!_initialized)
                throw new Exception("SecurityManager non inizializzato!!!");
        }

        public virtual ISecurityUser CurrentUser {
            get
            {
                return _currentUser;
            }
        }

        public virtual bool Authorize(string roleName)
        {
            CheckInitializzation();


            if (_currentUser == null)
                return false;


            return _currentUser.ContainsRole(roleName);

        }

        public virtual string CryptoPassword(string password)
        {
            CheckInitializzation();

            char[] passwordchar = password.ToCharArray();
            Array.Reverse(passwordchar);

            return new string(passwordchar);

        }

        public virtual void Initialize(ISecurityStore store)
        {
            _store = store;
            _initialized = true;
        }

        public virtual LoginResult Login(string username, string password)
        {
            CheckInitializzation();

            _currentUser = null;
            ISecurityUser user = _store.GetUserByUsername(username);
            if (user == null)
                return new LoginResult()
                {
                    Authenticated = false,
                    AuthenticationMessage = "Username o password errati"
                };
            if (ValidatePassword(user,password))
            {
                _currentUser = user;
                return new LoginResult()
                {
                    Authenticated = true
                };
            }

            return new LoginResult()
            {
                Authenticated = false,
                AuthenticationMessage = "Username o password errati"
            };

        }

        public virtual void RegisterUser(ISecurityUser user)
        {
            CheckInitializzation();

            user.Password = CryptoPassword(user.Password);
            _store.RegisterUser(user);



        }

        public virtual bool ValidatePassword(ISecurityUser user, string passwordToValidate)
        {
            CheckInitializzation();

            string encryptedPwd = CryptoPassword(passwordToValidate);

            if (encryptedPwd.Equals(user.Password))
                return true;


            return false;

        }
    }
}
