using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using BWMS.Infrastructure.Messaging;
using BWMS.WorkshopManagementEventHandler.DataAccess;
using BWMS.WorkshopManagementEventHandler.Events;
using BWMS.WorkshopManagementEventHandler.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BWMS.WorkshopManagementEventHandler
{
    public class EventHandler : IHostedService, IMessageHandlerCallback
    {
        WorkshopManagementDBContext _dbContext;
        IMessageHandler _messageHandler;

        public EventHandler(IMessageHandler messageHandler, WorkshopManagementDBContext dbContext)
        {
            _messageHandler = messageHandler;
            _dbContext = dbContext;
        }

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _messageHandler.Start(this);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _messageHandler.Stop();
            return Task.CompletedTask;
        }

        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            JObject messageObject = MessageSerializer.Deserialize(message);
            try
            {
                switch (messageType)
                {
                    case "CustomerRegistered":
                        await HandleAsync(messageObject.ToObject<CustomerRegistered>());
                        break;
                    case "VehicleRegistered":
                        await HandleAsync(messageObject.ToObject<VehicleRegistered>());
                        break;
                    case "MaintenanceJobPlanned":
                        await HandleAsync(messageObject.ToObject<MaintenanceJobPlanned>());
                        break;
                    case "MaintenanceJobFinished":
                        await HandleAsync(messageObject.ToObject<MaintenanceJobFinished>());
                        break;
                }
            }
            catch(Exception ex)
            {
                string messageId = messageObject.Property("MessageId") != null ? messageObject.Property("MessageId").Value<string>() : "[unknown]";
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", messageType, messageId);
            }

            // always akcnowledge message - any errors need to be dealt with locally.
            return true; 
        }

        private async Task<bool> HandleAsync(VehicleRegistered e)
        {
            Log.Information("Register Vehicle: {Name}, {Brand}, {Type}, Owner Id: {OwnerId}", 
                e.Name, e.Brand, e.Type, e.OwnerId);

            try
            {
                await _dbContext.Vehicles.AddAsync(new Vehicle
                {
                    Name = e.Name,
                    Brand = e.Brand,
                    Type = e.Type,
                    OwnerId = e.OwnerId
                });
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                Console.WriteLine($"Skipped adding vehicle with license number {e.Name}.");
            }

            return true;
        }

        private async Task<bool> HandleAsync(CustomerRegistered e)
        {
            Log.Information("Register Customer: {CustomerId}, {Name}, {TelephoneNumber}", 
                e.CustomerId, e.Name, e.TelephoneNumber);

            try
            {
                await _dbContext.Customers.AddAsync(new Customer
                {
                    CustomerId = e.CustomerId,
                    Name = e.Name,
                    TelephoneNumber = e.TelephoneNumber
                });
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                Log.Warning("Skipped adding customer with customer id {CustomerId}.", e.CustomerId);
            }

            return true; 
        }

        private async Task<bool> HandleAsync(MaintenanceJobPlanned e)
        {
            Log.Information("Register Maintenance Job: {JobId}, {StartTime}, {EndTime}, {CustomerName}, {Name}", 
                e.JobId, e.StartTime, e.EndTime, e.CustomerInfo.Name, e.VehicleInfo.Name);

            try
            {
                // determine customer
                Customer customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == e.CustomerInfo.Id);
                if (customer == null)
                {
                    customer = new Customer
                    {
                        CustomerId = e.CustomerInfo.Id,
                        Name = e.CustomerInfo.Name,
                        TelephoneNumber = e.CustomerInfo.TelephoneNumber
                    };
                }

                // determine vehicle
                Vehicle vehicle = await _dbContext.Vehicles.FirstOrDefaultAsync(v => v.Name == e.VehicleInfo.Name);
                if (vehicle == null)
                {
                    vehicle = new Vehicle
                    {
                        Name = e.VehicleInfo.Name,
                        Brand = e.VehicleInfo.Brand,
                        Type = e.VehicleInfo.Type,
                        OwnerId = customer.CustomerId
                    };
                }

                // insert maintetancejob
                await _dbContext.MaintenanceJobs.AddAsync(new MaintenanceJob
                {
                    Id = e.JobId,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    Customer = customer,
                    Vehicle = vehicle,       
                    WorkshopPlanningDate = e.StartTime.Date,
                    Description = e.Description
                });
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                Log.Warning("Skipped adding maintenance job with id {JobId}.", e.JobId);
            }

            return true;
        }

        private async Task<bool> HandleAsync(MaintenanceJobFinished e)
        {
            Log.Information("Finish Maintenance job: {JobId}, {ActualStartTime}, {EndTime}",
                e.JobId, e.StartTime, e.EndTime);

            try
            {
                // insert maintetancejob
                var job = await _dbContext.MaintenanceJobs.FirstOrDefaultAsync(j => j.Id == e.JobId);
                job.ActualStartTime = e.StartTime;
                job.ActualEndTime = e.EndTime;
                job.Notes = e.Notes;
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                Log.Warning("Skipped adding maintenance job with id {JobId}.", e.JobId);
            }

            return true;
        }
    }
}
