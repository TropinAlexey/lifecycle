using BWMS.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BWMS.WorkshopManagementAPI.Commands
{
    public class PlanMaintenanceJob : Command
    {
        public readonly Guid JobId;
        public readonly DateTime StartTime;
        public readonly DateTime EndTime;
        public readonly (string Id, string Name, string TelephoneNumber) CustomerInfo;
        public readonly (string Name, string Brand, string Type) VehicleInfo;
        public readonly string Description;

        public PlanMaintenanceJob(Guid messageId, Guid jobId, DateTime startTime, DateTime endTime,
            (string Id, string Name, string TelephoneNumber) customerInfo,
            (string Name, string Brand, string Type) vehicleInfo,
            string description) : base(messageId)
        {
            JobId = jobId;
            StartTime = startTime;
            EndTime = endTime;
            CustomerInfo = customerInfo;
            VehicleInfo = vehicleInfo;
            Description = description;
        }
    }
}
