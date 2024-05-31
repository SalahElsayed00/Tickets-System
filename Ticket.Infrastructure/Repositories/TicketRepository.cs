using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Entities;
using Ticket.Core.IRepository;
using Ticket.Infrastructure.Data;

namespace Ticket.Infrastructure.Repositories
{
    public class TicketRepository : IRepository<Tickket>
    {
        private readonly TicketDbContext _context;

        public TicketRepository(TicketDbContext context)
        {
            _context = context;
        }

        public async Task<Tickket> GetByIdAsync(int id)
        => await _context.Tickets.FindAsync(id);


        public async Task<IEnumerable<Tickket>> GetAllAsync(int page = 1, int pageSize = 5)
         => await _context.Tickets.OrderBy(t => t.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
 
        public async Task AddAsync(Tickket entity)
        {
            _context.Tickets.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Tickket> UpdateAsync(Tickket entity)
        {
            _context.Tickets.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }

}
