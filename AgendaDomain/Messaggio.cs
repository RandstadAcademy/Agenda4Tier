using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain
{
    public class Messaggio
    {
        public string Body { get; set; }
        public string  To { get; set; }
        public string From { get; set; }
        public string MessageObject { get; set; }
        public string Tel { get; set; }
    }
}
