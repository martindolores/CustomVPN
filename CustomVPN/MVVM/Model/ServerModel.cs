using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomVPN.MVVM.Model
{
    class ServerModel
    {
        public int ID{ get; set; }
        public string Username{ get; set; }
        public string Password{ get; set; }
        public string Server{ get; set; }
        public string Country{ get; set; }
    }
}
