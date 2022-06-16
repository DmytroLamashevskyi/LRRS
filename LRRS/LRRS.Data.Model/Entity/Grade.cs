using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity
{
    public class Grade
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }

        [Range(0, 100)]
        [Display(Name = "Points")]
        public int Points { set; get; }
         
        [ForeignKey("Student Id")]
        public string StudentId { set; get; }

        [ForeignKey("Lesson ID")]
        public string LessonId { set; get; }

        public virtual ApplicationUser User { set; get; }
        public virtual Lesson Lesson { set; get; }
    }
}
