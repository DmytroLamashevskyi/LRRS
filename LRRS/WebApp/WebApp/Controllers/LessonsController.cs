using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LRRS.Data.Model.Entity;
using LRRS.Data.Model.Entity.Identity;
using LRRS.Queries.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LessonsController(UserManager<ApplicationUser> userManager ,ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Lessons
        public async Task<IActionResult> Index(string courceId)
        {
            return View(_context.Cources.FirstOrDefault(l => l.Id == courceId && !l.IsDeleted).Lessons);
        }

        // GET: Lessons/Details/5
        public IActionResult Details(string id)
        {
            var Input = new LessonViewModel().GetLessonById(_context, id);
            if (Input == null)
            {
                return NotFound();
            }
            return View(Input);
        } 

        /// <summary>
        /// Create from Cours view
        /// </summary>
        /// <param name="cource"></param>
        /// <returns></returns>
        public IActionResult Create(Cource cource)
        {
            var Input = new LessonViewModel();
            Input.Cource = cource;
             
            return View(Input);
        }

        /// <summary>
        /// Create button on Lesson View Create
        /// </summary>
        /// <param name="lessonViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonViewModel lessonViewModel)
        {
            if (ModelState.IsValid)
            {
                lessonViewModel.CreateLesson(_context);  
                return RedirectToAction("Details", "Cources", new { Id = lessonViewModel.Cource.Id });
            }
            return View(lessonViewModel);
        }

        /// <summary>
        /// Click on Edit button in Cours view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(string id)
        {

            var Input = new LessonViewModel().GetLessonById(_context, id);
            if (Input == null)
            {
                return NotFound();
            }
            return View(Input);
        }

        /// <summary>
        /// Save edited lesson by submit button
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courceLesson"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LessonViewModel courceLesson)
        {  
            if (ModelState.IsValid)
            {
                try
                {
                    courceLesson.UpdateLesson(_context);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(courceLesson.Lesson.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Cources", new { Id = courceLesson.Cource.Id });
            }
            return Details(courceLesson.Lesson.Id);
        } 

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(string id)
        { 

            var lesson = await _context.Lessons.FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            } 

            return View(new LessonViewModel() {Lesson = lesson});
        }


        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            var cource =  _context.Cources.Where(c=>c.Lessons.Contains(lesson)).FirstOrDefault();
            lesson.IsDeleted = true;
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Cources", new { Id = cource.Id });
        }

        private bool LessonExists(string id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }
    }
}
