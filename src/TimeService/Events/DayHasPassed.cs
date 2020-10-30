using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BWMS.TimeService.Events
{
    public class DayHasPassed : Event
    {
        public DayHasPassed(Guid messageId) : base(messageId)
        {
        }
    }
}
