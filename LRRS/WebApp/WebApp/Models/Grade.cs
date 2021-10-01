using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }

        [Range(0,100)]
        public int Value { set; get; }
        public string UserId { set; get; }
        public virtual ApplicationUser User { set; get; }
        public string LessonId { set; get; }
        public virtual Lesson Lesson { set; get; }   


    }
}
