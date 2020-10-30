using System;
using System.Collections.Generic;

namespace BWMS.Models
{
    public class WorkshopPlanning
    {
        public DateTime Date { get; set; }
        public List<MaintenanceJob> Jobs { get; set; }
    }
}
