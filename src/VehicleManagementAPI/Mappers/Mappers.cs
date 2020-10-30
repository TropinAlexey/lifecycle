using BWMS.Application.VehicleManagement.Commands;
using BWMS.Application.VehicleManagement.Model;

namespace BWMS.VehicleManagementAPI.Mappers
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