using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.CoreModel
{
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }    
        [Required]
        public string Culture { get; set; }  

        public virtual ICollection<StringResource> StringResources { get; set; } = new HashSet<StringResource>();
    }
}
