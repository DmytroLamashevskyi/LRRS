using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity.Quiz
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }
        [Required]
        public string Header { set; get; }

        [Display(Name = "Begin")]
        public DateTime Start { set; get; } 
        [Display(Name = "Finish")]
        public DateTime End { set; get; }
        
        [ForeignKey("Id")]
        public string LessonId { set; get; }

        public virtual Lesson Lesson { set; get; }
        public ICollection<Question> Questions { get; set; } 
    }
}
