using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public enum Roles
    {
        SuperAdmin,
        Administrator,
        Lecturer,
        Student,
        Visitor
    }
     
    public enum QuestionType
    {
        SingleOption,
        OpenAnswer
    }
}
