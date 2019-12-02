using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tsaika_Clients.Models
{
    public class ClientsContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }

        public ClientsContext() : base("Clients")
    { 
    if (!Database.Exists())
                Database.Create();

            SaveChanges();
     }
           

    }
    
}