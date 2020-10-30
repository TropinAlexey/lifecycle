using Pitstop.Application.VehicleManagement.Commands;
using Pitstop.Application.VehicleManagement.Model;

namespace Pitstop.VehicleManagementAPI.Mappers
{
    public static class Mappers
    {
        public static Vehicle MapToVehicle(this RegisterVehicle command) => new Vehicle
        {
            Name = command.Name,
            Brand = command.Brand,
            Type = command.Type,
            OwnerId = command.OwnerId
        };
    }
}