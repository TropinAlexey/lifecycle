using Pitstop.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BWMS.Application.VehicleManagement.Commands
{
    public class RegisterVehicle : Command
    {
        public readonly string Name;
        public readonly string Brand;
        public readonly string Type;
        public readonly string OwnerId;

        public RegisterVehicle(Guid messageId, string name, string brand, string type, string ownerId) : 
            base(messageId)
        {
            Name = name;
            Brand = brand;
            Type = type;
            OwnerId = ownerId;
        }
    }
}
