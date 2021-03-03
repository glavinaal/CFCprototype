using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CFCprototype.Models;

namespace CFCprototype.Data
{
    public class CFCprototypeContext : DbContext
    {
        public CFCprototypeContext (DbContextOptions<CFCprototypeContext> options)
            : base(options)
        {
        }

        public DbSet<CFCprototype.Models.Event> Event { get; set; }

        public DbSet<CFCprototype.Models.MembersClassifieds> MembersClassifieds { get; set; }

        public DbSet<CFCprototype.Models.Sermon> Sermon { get; set; }

        public DbSet<CFCprototype.Models.PrayerRequest> PrayerRequest { get; set; }
    }
}
