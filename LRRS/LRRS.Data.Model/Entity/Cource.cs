using LRRS.Data.Model.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity
{
    [Table("Cources")]
    public class Cource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [MaxLength(120)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [ForeignKey("OwnerId")]
        public string OwnerId { get; set; }

        [MaxLength(16)]
        [Display(Name = "Password")]
        public string Password { set; get; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { set; get; }

        [DataType(DataType.Date)]
        [Display(Name = "CreationDate")]
        public DateTime CreationDate { set; get; }

        public virtual ApplicationUser Owner { get; set; }
        public virtual ICollection<ApplicationUser> Students { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
