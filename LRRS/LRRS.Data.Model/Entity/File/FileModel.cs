using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity.File
{
    public class FileModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name = "File Name")]
        public string Name { get; set; }

        [Display(Name = "File Type")]
        public string FileType { get; set; }

        [Display(Name = "Extension")]
        public string Extension { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [ForeignKey("OwnerId")]
        [Display(Name = "Uploaded By")]
        public string OwnerId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created  Date")]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Deleted Date")]
        public DateTime DeletedDate { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }
        public virtual ApplicationUser Owner { set; get; }
    }
}
