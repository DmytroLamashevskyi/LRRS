using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public abstract class FileModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }

        [ForeignKey("OwnerId")]
        public string UploadedBy { get; set; }
        public DateTime? CreatedOn { get; set; } 
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ApplicationUser Owner { set; get; }
    }
}
