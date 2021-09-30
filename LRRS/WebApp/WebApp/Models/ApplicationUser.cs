using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SerialPassport { set; get; }
        public string StudentId { set; get; } 
        public byte[] ProfilePicture { get; set; }
         
        public ICollection<Cource> Cources { get; set; }
    }
}
