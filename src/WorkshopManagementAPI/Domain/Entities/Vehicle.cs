using BWMS.WorkshopManagementAPI.Domain.Core;
using BWMS.WorkshopManagementAPI.Domain.ValueObjects;

namespace BWMS.WorkshopManagementAPI.Domain.Entities
{
    public class Vehicle : Entity<Name>
    {
        public string Brand { get; private set; }
        public string Type { get; private set; }
        public string OwnerId { get; private set; }

        public Vehicle(Name Name, string brand, string type, string ownerId) : base(Name)
        {
            Brand = brand;
            Type = type;
            OwnerId = ownerId;
        }
    }
}
