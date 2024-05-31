using FluentValidation.AspNetCore;
using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Ticket.Application.Commands.Create;
using Ticket.Core.Entities;
using Ticket.Core.IRepository;
using Ticket.Infrastructure.Data;
using Ticket.Infrastructure.Repositories;
using Tickets.Api.Controllers;

namespace Tickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<TicketDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IRepository<Tickket>, TicketRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateTicketCommand).Assembly));
            builder.Services.AddHostedService<TicketStatusUpdateService>();
            builder.Services.AddControllers().AddFluentValidation();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
