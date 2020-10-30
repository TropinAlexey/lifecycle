using BWMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BWMS.ViewModels
{
    public class WorkshopManagementDetailsViewModel
    {
        public DateTime Date { get; set; }
        public MaintenanceJob MaintenanceJob { get; set; }
    }
}
