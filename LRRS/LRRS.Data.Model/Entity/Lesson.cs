using LRRS.Data.Model.Entity.File;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }

        [Required]
        [MinLength(4)]
        [Display(Name = "Name")]
        public string Name { set; get; }

        [DataType(DataType.Html)]
        [Display(Name = "Description")]
        public string Description { set; get; }

        [Required]
        [ForeignKey("Cource ID")]
        public string CourceId { set; get; }
        [Required]
        [ForeignKey("Author ID")]
        public string AuthorId { set; get; }

        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { set; get; } = DateTime.Today;

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { set; get; }


        public Cource Cource { set; get; }
        public ApplicationUser Author { set; get; }
        public virtual ICollection<Grade> Marks { set; get; }
        public virtual ICollection<FileModel> Files { set; get; }
        public virtual ICollection<Quiz.Quiz> Quizzes { set; get; }
    }
}
