using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAB32.Models
{
    public class DAB32Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DAB32Context() : base("name=DAB32Context")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<DAB32.Models.Adresse> Adresses { get; set; }

        public System.Data.Entity.DbSet<DAB32.Models.ByPostNummer> ByPostNummers { get; set; }

        public System.Data.Entity.DbSet<DAB32.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<DAB32.Models.PersonAdresse> PersonAdresses { get; set; }

        public System.Data.Entity.DbSet<DAB32.Models.TelefonNummer> TelefonNummers { get; set; }
    }
}
