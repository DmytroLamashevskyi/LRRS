using LRRS.Data.Model.Entity;
using LRRS.Data.Model.Entity.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ManageUserViewModel
    {
        public ApplicationUser User { set; get; }
        public IEnumerable<string> Roles { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string UnsavePassword { set; get; }

        
        [TempData]
        public string StatusMessage { set; get; }
    }
}
