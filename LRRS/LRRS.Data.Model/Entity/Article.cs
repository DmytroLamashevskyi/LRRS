using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }

        [Required]
        [MinLength(4,ErrorMessage ="Min header length 4 characters.")]
        [Display(Name = "Name")]
        public string Header { set; get; }

        [Display(Name = "Message")]
        public string Message { set; get; }

        [Display(Name = "Short Message")]
        [MaxLength(100, ErrorMessage = "Max message length 100 characters.")]
        public string? ShortMessage { set; get; }

        public string? ImageUrl { set; get; }




    }
}
