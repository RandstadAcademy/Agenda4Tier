using PersistenceSystem;
using SecuritySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain.Security
{
    public class Utente: AbstractDomainObject, ISecurityUser
    {
        private string _password;
        private string _username;
        private string _nameAndSurname;
        private string _mail;
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
                if (_roles == null)
                    _roles = new List<IRole>();
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

        public string Mail
        {
            get
            {
                return _mail;
            }

            set
            {
                _mail = value;
            }
        }

        public string NameAndSurname
        {
            get
            {
                return _nameAndSurname;
            }

            set
            {
                _nameAndSurname = value;
            }
        }

        public override string DoValidate()
        {
            string MsgErrore = "";

            //verifico se le stringhe immesse siano vuote o null
            if (string.IsNullOrEmpty(Username))
                MsgErrore += "Username Errato\n";

            if (string.IsNullOrEmpty(Password))
                MsgErrore += "Password Errata\n";

            if (string.IsNullOrEmpty(Mail))
                MsgErrore += "Mail Errata\n";

            if (string.IsNullOrEmpty(NameAndSurname))
                MsgErrore += "Nome e Cognome Errato\n";

            if (Roles.Count == 0)
                MsgErrore += "Ruoli errati\n";

            //se è andato tutto bene il messaggio di errore è vuoto
            return MsgErrore;
        }

        public bool ContainsRole(string roleName)
        {
            if (_roles == null)
                return false;

            return _roles.Exists(a => a.Name.Equals(roleName));
        }
    }
}
