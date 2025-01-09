using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessages.Models
{
    public class TwilioSettings
    {
        public int Id { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
    }
}
