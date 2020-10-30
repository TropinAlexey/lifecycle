using BWMS.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BWMS.WorkshopManagementAPI.Events
{
    public class WorkshopPlanningCreated : Event
    {
        public readonly DateTime Date;

        public WorkshopPlanningCreated(Guid messageId, DateTime date) : base(messageId)
        {
            Date = date;
        }
    }
}
