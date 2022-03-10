using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebApp.Models
{
    public class Question
    {
        [Key]
        public string Id { set; get; }
        [Required]
        public string QuestionData { set; get; }
        public QuestionType QuestionType { set; get; }


        [Required] 
        public string Answer { set; get; }

        public string OptionString { set; get; }
         
        [NotMapped] 
        public List<string> OptionList { set => OptionString = JsonConvert.SerializeObject(value); get => JsonConvert.DeserializeObject<List<string>>(OptionString); } 


        public ICollection<UserTestMarks> TestMarks { set; get; }
    }
} 