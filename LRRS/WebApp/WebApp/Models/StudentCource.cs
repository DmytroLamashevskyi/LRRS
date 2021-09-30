using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class StudentCource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { set; get; }

        public string StudentId { set; get; }
        public ApplicationUser Student { set; get; }
        public string CourceId { set; get; }
        public Cource Cource { set; get; }

    }
}
