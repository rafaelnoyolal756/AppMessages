using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessages.Models
{
    public class SentMessage
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public DateTime Sent { get; set; }
        public string ConfirmationCode { get; set; }
    }
}
