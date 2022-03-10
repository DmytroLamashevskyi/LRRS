using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ClassesTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public virtual List<Question> Questions { set; get; }

        [ForeignKey("Lesson")]
        public string LessonId { set; get; }
        public string Header { set; get; } 
        public string Description { set; get; }
        
        public ICollection<UserTestMarks> TestMarks { set; get; }
    }
}
