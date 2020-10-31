using Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using WorkshopManagementAPI.Domain.Core;

namespace BWMS.WorkshopManagementAPI.Domain.ValueObjects
{
    public class WorkshopPlanningId : ValueObject
    {
        public string Value { get; private set; }

        public static WorkshopPlanningId Create(DateTime date)
        {
            return new WorkshopPlanningId { Value = date.ToString(ConfigurationExtension.GetDateFormat) };
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static implicit operator string(WorkshopPlanningId id) => id.Value;
        public static implicit operator DateTime(WorkshopPlanningId id) =>
            DateTime.ParseExact(id.Value, ConfigurationExtension.GetDateFormat, CultureInfo.InvariantCulture);
    }
}