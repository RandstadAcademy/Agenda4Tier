using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private string CalculateMD5Hash(string input)

        {

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();

        }

        public virtual string CryptoPassword(string password)
        {
            CheckInitializzation();
            
            return CalculateMD5Hash(password);
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
