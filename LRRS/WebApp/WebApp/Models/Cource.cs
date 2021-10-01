using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Cource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; } 
        public string Description { get; set; } 

        [ForeignKey("Id")]
        public string OwnerId { get; set; } 
        public string Password { set; get; } 
        public bool IsDeleted { set; get; }
        public DateTime CreationDate { set; get; } 

        public virtual ApplicationUser Owner { get; set; } 
        public virtual ICollection<ApplicationUser> Students { get; set; } 
        public virtual ICollection<Lesson> Lessons { get; set; }  

    }
}
