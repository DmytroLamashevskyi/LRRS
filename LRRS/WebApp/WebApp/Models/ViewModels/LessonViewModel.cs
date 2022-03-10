using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Models
{ 
    public class LessonViewModel 
    {
        public string CourceId { get; set; }
        public string LessonId { get; set; }
        public Cource Cource { get; set; } 
        public Lesson Lesson { get; set; } 


        public LessonViewModel GetLessonById(ApplicationDbContext _context, string lessonId)
        {
            if (string.IsNullOrEmpty(lessonId))
            {
                return null;
            }

             
            this.Lesson = _context.Lessons.FirstOrDefault(m => m.Id == lessonId && !m.IsDeleted);
            if(this.Lesson == null)
            {
                return null;
            }
            else
            { 
                this.Cource = _context.Cource.FirstOrDefault(c => c.Id == this.Lesson.CourceId);
                CourceId = this.Lesson.CourceId;
                LessonId = lessonId;

            }

            return this;
        }

        public LessonViewModel CreateLesson(ApplicationDbContext _context)
        {
            this.Lesson.CourceId = this.Cource.Id;

            _context.Add(this.Lesson);
            _context.SaveChanges();


            var usersList = _context.Students.Where(s => s.CourceId == this.Cource.Id);

            foreach (var users in usersList)
            {
                var mark = new Grade()
                {
                    UserId = users.StudentId,
                    LessonId = this.Lesson.Id
                };
                _context.Grades.Add(mark);
            }

            _context.SaveChanges();

            return this;
        }

        public LessonViewModel DeleteLeson(ApplicationDbContext _context, string lessoIid)
        { 

            var lesson =  _context.Lessons.FirstOrDefault(m => m.Id == this.Lesson.Id);
            if (lesson == null)
            {
                return null;
            }

            return this; 
        }

        public void UpdateLesson(ApplicationDbContext _context)
        {
            var LessonData = _context.Lessons.Where(x => x.Id == Lesson.Id).FirstOrDefault();
            if (LessonData != null)
            {
                LessonData.Name = this.Lesson.Name;
                LessonData.DateTime = this.Lesson.DateTime;
                LessonData.Description = this.Lesson.Description;
                LessonData.Files = this.Lesson.Files;
                _context.Entry(LessonData).State = EntityState.Modified;
                _context.SaveChanges();
            } 
        }
    }
}
