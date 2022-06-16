using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity.Quiz
{
    public class UserMark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }

        [ForeignKey("Id")]
        public string StudentId { set; get; }

        [ForeignKey("Id")]
        public string LessonId { set; get; }

        [Range(0, 100, ErrorMessage = "Min points 0 Max points 100.")]
        [Display(Name = "Points")]
        public string Points { set; get; }
        public string Details { set; get; }

        public virtual ApplicationUser Student { get; set; }
        public virtual Lesson Lesson { get; set; } 
    }
}
