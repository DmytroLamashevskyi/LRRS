using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity.Quiz
{
    public class QuestionOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; } 

        [Required(ErrorMessage = "Option text is required")] 
        [Display(Name = "Option Text")]
        public string Text { set; get; }

        [Display(Name = "Is Correct")]
        public bool IsCorrect { set; get; }
        
        [Range(1,100,ErrorMessage = "Min points 1 Max points 100.")]
        [Display(Name = "Points")]
        public int Points { set; get; }

        [ForeignKey("Id")]
        public string QuestionId { set; get; }

        public virtual Question Question { set; get; }

    }
}
