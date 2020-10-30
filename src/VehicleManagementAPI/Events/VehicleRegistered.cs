using BWMS.Application.VehicleManagement.Commands;
using BWMS.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BWMS.Application.VehicleManagement.Events
{
    public class VehicleRegistered : Event
    {
        public readonly string Name;
        public readonly string Brand;
        public readonly string Type;
        public readonly string OwnerId;

        public VehicleRegistered(Guid messageId, string Name, string brand, string type, string ownerId) : 
            base(messageId)
        {
            Name = Name;
            Brand = brand;
            Type = type;
            OwnerId = ownerId;
        }

        public static VehicleRegistered FromCommand(RegisterVehicle command)
        {
            return new VehicleRegistered(
                Guid.NewGuid(),
                command.Name,
                command.Brand,
                command.Type,
                command.OwnerId
            );
        }
    }
}
