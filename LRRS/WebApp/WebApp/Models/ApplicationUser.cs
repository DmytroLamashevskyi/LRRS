using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(12, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }


        [RegularExpression(@"^(?!^0+$)[a-zA-Z0-9]{6,9}$", ErrorMessage = "Please enter your Passport Number with leters.")]
        public string SerialPassport { set; get; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { set; get; }
        public string Country { set; get; }
         
        [StringLength(13)]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Please, Enter valid Student Id Number.")]
        public string StudentId { set; get; } 
        public byte[] ProfilePicture { get; set; } 
        public bool IsBlocked { set; get; }

        public virtual ICollection<FileModel> Files { get; set; }
        public virtual ICollection<Cource> Cources { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<UserTestMarks> TestMarks { set; get; }
    }
}
