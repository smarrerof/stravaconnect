using StravaConnect.Athletes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaConnect.UWP
{

    public class AuthResponse
    {
        public string access_token { get; set; }
        public Athlete athlete { get; set; }
    }
}
