using Microsoft.AspNetCore.Mvc.Rendering;
using BWMS.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BWMS.ViewModels
{
    public class VehicleManagementNewViewModel
    {
        public Vehicle Vehicle { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        [Required(ErrorMessage = "Owner is required")]
        public string SelectedCustomerId { get; set; }
    }
}
