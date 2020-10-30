using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BWMS.Models
{
    public class Vehicle
    {
        [Required]
        [Display(Name = "Give a name for your bike")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "What brand?")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "What type?")]
        public string Type { get; set; }

        [Display(Name = "Who are it's owner?")]
        public string OwnerId { get; set; }
    }
}