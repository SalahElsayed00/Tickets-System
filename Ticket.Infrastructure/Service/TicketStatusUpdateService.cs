using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ticket.Core.Entities;
using Ticket.Core.IRepository;

namespace Infrastructure.Services
{
    public class TicketStatusUpdateService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public TicketStatusUpdateService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdateTicketStatus, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            _timer = new Timer(UpdateTicketColor, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private void UpdateTicketStatus(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IRepository<Tickket>>();
                var tickets = repository.GetAllAsync(1, 10).Result;

                foreach (var ticket in tickets)
                {
                    if (ticket.CreationDateTime < DateTime.UtcNow.AddMinutes(-60))
                    {
                        ticket.Status = "Handled";
                        repository.UpdateAsync(ticket).Wait();
                    }
                }
            }
        }

        private void UpdateTicketColor(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IRepository<Tickket>>();
                var tickets = repository.GetAllAsync(1, 10).Result;

                var currentTime = DateTime.UtcNow;

                foreach (var ticket in tickets)
                {
                    ticket.Color = GetTicketColor(ticket.CreationDateTime, currentTime);
                    repository.UpdateAsync(ticket).Wait();
                }
            }
        }

        private string GetTicketColor(DateTime creationDateTime, DateTime currentTime)
        {
            var minutesElapsed = (currentTime - creationDateTime).TotalMinutes;

            if (minutesElapsed >= 60)
                return "Red";
            else if (minutesElapsed >= 45)
                return "Blue";
            else if (minutesElapsed >= 30)
                return "Green";
            else if (minutesElapsed >= 15)
                return "Yellow";
            else
                return "Undefined";
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
