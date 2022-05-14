using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public class MMSDbContext : DbContext
    {

        public MMSDbContext(DbContextOptions<MMSDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<NotifyHeader> NotifyHeaders { get; set; }
        public DbSet<NotifyDetail> NotifyDetails { get; set; }

    }
}