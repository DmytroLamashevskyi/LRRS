using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class UserTestMarks
    {
        [Key]
        public string Id { set; get; } 
        public int TestGroupId { set; get; }

        [ForeignKey("Id")]
        public string UserId { set; get; }
        public ApplicationUser Student { set; get; }

        [ForeignKey("Id")]
        public string QuestionId { set; get; }
        public Question Question { set; get; }

        [ForeignKey("Id")]
        public string TestId { set; get; }
        public ClassesTest ClassesTest { set; get; }

        public string UserAnswer { set; get; }

        public bool IsCorect { set; get; }
    }
}
