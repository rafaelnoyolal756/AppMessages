using AppMessages.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMessages.Data
{
    public class SQLServerContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }
        public DbSet<TwilioSettings> TwilioSettings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER = DIVPORT-38924\SQLEXPRESS; Initial Catalog = APPUI1;TRUSTED_CONNECTION=TRUE;Integrated Security=SSPI;TrustServerCertificate=True");
        }
    }
}
