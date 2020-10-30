using System;
using System.Collections.Generic;
using BWMS.WorkshopManagementAPI.Domain.Entities;

namespace BWMS.WorkshopManagementAPI.DTOs
{
    public class WorkshopPlanningDTO
    {
        public DateTime Date { get; set; }
        public List<MaintenanceJobDTO> Jobs { get; set; }
    }
}
