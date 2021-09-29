﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Lesson
    {
        [Key]
        public string Id { set; get; }
        public string Name { set; get; } 
        public Cource Cource { set; get; }
        public ApplicationUser Author { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { set; get; }
        
        [DataType(DataType.Html)]
        public string Description { set; get; }
        public ICollection<FileModel> Files { set; get; } = new List<FileModel>();
    }
}