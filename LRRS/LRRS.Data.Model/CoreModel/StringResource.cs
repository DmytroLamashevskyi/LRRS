using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.CoreModel
{
    [Table("StringResources")]
    public class StringResource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [RegularExpression("[A-Za-z_.]", ErrorMessage = "Only Uppercase and Lowercase are awailable and dot  symbole.")]
        public string Key { get; set; }
        public string? Value { get; set; }

        [ForeignKey("LanguageId")]
        public int LanguageId { set; get; }
    }
}
