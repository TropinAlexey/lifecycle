using BWMS.Models;
using System.Collections.Generic;

namespace BWMS.ViewModels
{
    public class CustomerManagementViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
