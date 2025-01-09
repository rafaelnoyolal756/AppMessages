using AppMessages.Data;
using AppMessages.Models;
using AppMessages.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessages.BL
{
    public class SmallMessaging : Interface1
    {
        public async Task<List<Message>> GetListMessage()
        {
            using (var sqlserverContext = new SQLServerContext())
            {
                return await sqlserverContext.Messages.ToListAsync();
            }

            
        }

        public async Task<List<SentMessage>> GetListSentMessage()
        {
            using (var sqlserverContext = new SQLServerContext())
            {
                return await sqlserverContext.SentMessages.ToListAsync();
            }
            
        }

        public async Task<Message> GetMessage(int MessageId)
        {
            using (var sqlserverContext = new SQLServerContext())
            {
                return await sqlserverContext.Messages.Where(x => x.Id == MessageId).FirstOrDefaultAsync();
            }
            
        }

        public async Task<SentMessage> GetSentMessage(int SentMessageId)
        {
            using (var sqlserverContext = new SQLServerContext())
            {
                return await sqlserverContext.SentMessages.Where(x => x.Id == SentMessageId).FirstOrDefaultAsync();
            }
           
        }

        public async Task<int> InsertMessage(Message Message)
        {
            using (var sqlserverContext = new SQLServerContext())
            {
                Message.Created = DateTime.Now;
                sqlserverContext.Add(Message);
                await sqlserverContext.SaveChangesAsync();
            }
            int id = Message.Id;
            return id;
            
        }
        public async Task<bool> InsertSentMessage(SentMessage SentMessage)
        {
            using (var sqlserverContext = new SQLServerContext())
            {
                sqlserverContext.Add(SentMessage);
                await sqlserverContext.SaveChangesAsync();
            }
            return true;
            ;
        }

        public async Task<bool> UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public async Task<TwilioSettings> GetTwilioSettings()
        {
            using (var sqlserverContext = new SQLServerContext())
            {
               return await sqlserverContext.TwilioSettings.Where(x => x.Id == 1).FirstOrDefaultAsync();
               
            }

        }
    }
}
