using BWMS.Infrastructure.Messaging;
using System;

namespace BWMS.NotificationService.Events
{
    public class MaintenanceJobFinished : Event
    {
        public readonly string JobId;

        public MaintenanceJobFinished(Guid messageId, string jobId) : 
            base(messageId)
        {
            JobId = jobId;
        }
    }
}
