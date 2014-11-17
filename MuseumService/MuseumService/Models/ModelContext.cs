using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MuseumService.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("ModelContextConnString") { }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Code> Codes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<AccessToken> AccessTokens { get; set; }

        public DbSet<Recode> Recodes { get; set; }

        public DbSet<Discuss> Discusses { get; set; }
    }
}