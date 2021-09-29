using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LessonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index(string courceId)
        {
            return View(await _context.Lessons.Select(l=>l.CourceId == courceId).ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }
            var Input = new CourceLessonViewModel();
            Input.Lesson = lesson;
            Input.Cource = await _context.Cource.FirstOrDefaultAsync(c => c.Id == lesson.CourceId);
            return View(Input);
        }




        public IActionResult Create(Cource cource)
        {
            var Input = new CourceLessonViewModel();
            Input.Cource = cource;
            return View(Input);
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourceLessonViewModel lessonViewModel)
        {
            lessonViewModel.Lesson.CourceId = lessonViewModel.Cource.Id;
            if (ModelState.IsValid)
            {
                _context.Add(lessonViewModel.Lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction( "Details", "Cources",new {Id = lessonViewModel.Cource.Id });
            }
            return View(lessonViewModel.Lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }
            var Input = new CourceLessonViewModel();
            Input.Lesson = lesson;
            Input.Cource = await _context.Cource.FirstOrDefaultAsync(c => c.Id == lesson.CourceId);

            return View(Input);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, CourceLessonViewModel courceLesson)
        {
            if (id != courceLesson.Lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courceLesson.Lesson);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction("Details", "Cources", new { Id = courceLesson.Lesson.CourceId });
            }
            return View(courceLesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            var cource = await _context.Cource.FindAsync(lesson.CourceId);
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Cources", new { Id = cource.Id });
        }

        private bool LessonExists(string id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }
    }
}
