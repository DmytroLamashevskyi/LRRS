using LRRS.Data.Model.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity.Quiz
{
    public class UserAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }
         
        [ForeignKey("Id")]
        public string UserId { set; get; }

        [ForeignKey("Id")]
        public string QuestionId { set; get; }

        [ForeignKey("Id")]
        public string QuestionOptionId { set; get; } 

        public virtual ApplicationUser Student { get; set; }
        public virtual Question Question { get; set; }
        public virtual QuestionOption Option { get; set; }
    }
}
