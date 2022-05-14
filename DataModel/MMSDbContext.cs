using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel
{
    public class MMSDbContext : DbContext
    {

        public MMSDbContext(DbContextOptions<MMSDbContext> options) : base(options)
        {

        }

        public DbSet<NotifyHeader> NotifyHeaders { get; set; }
        public DbSet<NotifyDetail> NOtifyDetails { get; set; }

    }
}