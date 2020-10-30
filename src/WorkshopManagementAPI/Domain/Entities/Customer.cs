using BWMS.WorkshopManagementAPI.Domain.Core;

namespace BWMS.WorkshopManagementAPI.Domain.Entities
{
    public class Customer : Entity<string>
    {
        public string Name { get; private set; }
        public string TelephoneNumber { get; private set; }

        public Customer(string customerId, string name, string telephoneNumber) : base(customerId)
        {
            Name = name;
            TelephoneNumber = telephoneNumber;
        }
    }
}
