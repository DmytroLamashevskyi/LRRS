using LRRS.Data.Model.Entity.File;
using LRRS.Data.Model.Entity.Quiz;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity.Identity
{
    public class ApplicationUser:  IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(12, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; } 

        [Display(Name = "Serial Passport")]
        [RegularExpression(@"^(?!^0+$)[a-zA-Z0-9]{6,9}$", ErrorMessage = "Please enter your Passport Number with leters.")]
        public string? SerialPassport { set; get; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { set; get; }

        [Display(Name = "Country")]
        public string? Country { set; get; }

        [StringLength(13)]
        [Display(Name = "Student ID")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Please, Enter valid Student Id Number.")]
        public string? StudentId { set; get; }

        [Display(Name = "Is Blocked")]
        public bool IsBlocked { set; get; }
        public byte[]? UserPicture { get; set; }


        public virtual ICollection<FileModel> Files { get; set; }
        public virtual ICollection<Cource> Cources { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<UserMark> TestMarks { set; get; }
    }
}
