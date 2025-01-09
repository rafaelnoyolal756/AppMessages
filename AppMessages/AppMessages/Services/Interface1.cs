using AppMessages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessages.Services
{
    public interface Interface1
    {
        Task<List<Message>> GetListMessage();
        Task<Message> GetMessage(int MessageId);
        Task<List<SentMessage>> GetListSentMessage();
        Task<SentMessage> GetSentMessage(int SentMessageId);
        Task<int> InsertMessage(Message Message);
        Task<bool> InsertSentMessage(SentMessage SentMessage);
        Task<bool> UpdateMessage(Message Message);
        Task<TwilioSettings> GetTwilioSettings();
    }
}
