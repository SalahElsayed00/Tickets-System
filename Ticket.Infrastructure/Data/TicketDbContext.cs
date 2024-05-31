using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Entities;
using Ticket.Infrastructure.Configurations.Infrastructure.Configurations;

namespace Ticket.Infrastructure.Data
{
    public class TicketDbContext : DbContext
    {
        public DbSet<Tickket> Tickets { get; set; }

        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var entries = ChangeTracker.Entries<Tickket>()
        //        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        //    foreach (var entityEntry in entries)
        //    {
        //        if (entityEntry.State == EntityState.Added)
        //        {
        //            entityEntry.Entity.Status = "New";
        //        }

        //        _ticketStatusService.UpdateTicketStatus(entityEntry.Entity);
        //    }

        //    return await base.SaveChangesAsync(cancellationToken);
        //}
    }

}
