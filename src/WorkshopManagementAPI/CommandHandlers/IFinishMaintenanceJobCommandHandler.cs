using System;
using System.Threading.Tasks;
using BWMS.WorkshopManagementAPI.Commands;
using BWMS.WorkshopManagementAPI.Domain.Entities;

namespace WorkshopManagementAPI.CommandHandlers
{
    public interface IFinishMaintenanceJobCommandHandler
    {
        Task<WorkshopPlanning> HandleCommandAsync(DateTime planningDate, FinishMaintenanceJob command);
    }
}