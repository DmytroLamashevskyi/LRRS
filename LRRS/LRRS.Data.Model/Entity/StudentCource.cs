using LRRS.Data.Model.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRRS.Data.Model.Entity
{
    public class StudentCource
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string CourceId { get; set; }
        public Cource Cource { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; } 
        public DateTime REgistrationDate { set; get; } 

    }
}
