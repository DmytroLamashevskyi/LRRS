using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }
        public string Name { set; get; } 

        public string CourceId { set; get; }
        public Cource Cource { set; get; }
        public ApplicationUser Author { set; get; }

        [DataType(DataType.Date)] 
        public DateTime DateTime { set; get; }
         
        [DataType(DataType.Html)]
        public string Description { set; get; }
        public bool IsDeleted { set; get; } 
        public virtual ICollection<Grade> Marks { set; get; }
        public virtual ICollection<FileModel> Files { set; get; }
    }
}
