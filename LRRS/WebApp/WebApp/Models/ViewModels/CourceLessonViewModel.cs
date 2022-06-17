using LRRS.Data.Model.Entity;
using LRRS.Data.Model.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.ViewModels
{
    public class CourceLessonViewModel
    {
        public Cource Cource { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<ApplicationUser> Students { get; set; }
    }
}
