using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LRRS.Data.Model.Entity;
using LRRS.Data.Model.Entity.Identity;
using LRRS.Queries.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore; 


namespace WebApp.Controllers
{
    public class CourcesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CourcesController(UserManager<ApplicationUser> userManager ,ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> RegisterOnCource(string id, string passwordString)
        {
           var cource = _context.Cources.FirstOrDefaultAsync(c => c.Id == id && c.Password == passwordString).Result;

            if (cource == null)
            {
                ViewBag.Message  = "Wrong password.";
                var cources = await _context.Cources.ToListAsync();
                cources = cources.Where(c => !c.IsDeleted).ToList();

                foreach (var item in cources)
                {
                    var studentsId = await _context.Students.Where(s => s.CourceId == item.Id).Select(s => s.StudentId).ToListAsync();
                    item.Students = await _context.Users.Where(u => studentsId.Contains(u.Id)).ToListAsync();
                }

                return View("Index", cources);
            }

            var findUser = _userManager.GetUserAsync(User).Result;


            if (findUser != null)
            {
                var data = new StudentCource()
                {
                    CourceId = id,
                    StudentId = findUser.Id
                };

                _context.Students.Add(data);

                List<Lesson> lesonList = new List<Lesson>() ; // _context.Lessons.Where(u => u.Cource.Id == data.CourceId && !u.IsDeleted).ToList();
                var marks = new List<Grade>();
                foreach (var leson in lesonList)
                {
                    var mark = new Grade()
                    {
                        StudentId = findUser.Id,
                        LessonId = leson.Id
                    };

                    _context.Grades.Add(mark);
                }
                _context.SaveChanges();

            }

            return RedirectToAction(nameof(Details), new { id = id });
        }


        // GET: Cources
        public async Task<IActionResult> Index(string searchString,string userId)
        {
            var cources = await _context.Cources.ToListAsync();
            cources = cources.Where(c =>!c.IsDeleted).ToList();
             
            if (!String.IsNullOrEmpty(userId))
            {
                 var courcesId = _context.Students.Where(s=>s.StudentId == userId).Select(c=>c.CourceId).ToList();
                 cources = cources.Where(c => (courcesId.Contains(c.Id) && !c.IsDeleted) || ( c.OwnerId== userId && !c.IsDeleted)).ToList();
            }else
            if (!String.IsNullOrEmpty(searchString))
            {
                cources = cources.Where(s => s.Name.Contains(searchString)).ToList();
            }

            foreach(var cource in cources)
            {
                var studentsId =await _context.Students.Where(s => s.CourceId == cource.Id).Select(s=>s.StudentId).ToListAsync();
                cource.Students = await _context.Users.Where(u => studentsId.Contains(u.Id)).ToListAsync();
            } 
            return View(cources);
        }
        // GET: Cources
        public async Task<IActionResult> AddStudent(string id)
        {
            TempData["id"] = id;
            var students = await _userManager.Users.ToListAsync();  
            return View(students);
        } 

        public async Task<IActionResult> SearchStudent(string searchString)
        {
            var users = await _userManager.Users.ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                var data = users.Where(s => {
                    bool? result = false;

                    result |= s.FirstName?.Contains(searchString);
                    result |= s.LastName?.Contains(searchString);
                    result |= s.UserName?.Contains(searchString);
                    result |= s.SerialPassport?.Contains(searchString);
                    result |= s.Email?.Contains(searchString);
                     
                    return result ?? false;
                });

                if (data != null)
                {
                    users = data.ToList();
                }
                else
                {
                    users = new List<ApplicationUser>();
                }

            }
             
            return View(users);
        }

        public async Task<IActionResult> AddUserToCource(string userId)
        {

            var data = new StudentCource()
            {
                CourceId = TempData["id"].ToString(),
                StudentId = userId
            };

            var findUser =  _context.Students.FirstOrDefault(s => s.CourceId == data.CourceId && s.StudentId == data.StudentId);
            if (findUser == null)
            {
                _context.Students.Add(data);

                var lesonList = new List<Lesson>();//_context.Lessons.Where(u => u.Cource.Id == data.CourceId && !u.IsDeleted).ToList();
                var marks = new List<Grade>();
                foreach (var leson in lesonList)
                {
                    var mark = new Grade()
                    {
                        StudentId = userId,
                        LessonId = leson.Id  
                    };

                    _context.Grades.Add(mark);
                }
                _context.SaveChanges();

                return RedirectToAction(nameof(Details), new { id = data.CourceId });
            }
            else 
                return RedirectToAction(nameof(AddStudent), new { id = data.CourceId });
        }

        public async Task<IActionResult> DeleteStudent(string courceid, string studentid)
        {
            if (string.IsNullOrEmpty(courceid) || string.IsNullOrEmpty(studentid))
            {
                return NotFound();
            }
            var student = _context.Students.Where(s => s.CourceId == courceid && s.StudentId == studentid).FirstOrDefaultAsync().Result;
            if (student == null)
            {
                return RedirectToAction("Details", "Cources", new { Id = courceid });
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Cources", new { Id = courceid });
        }


        // GET: Cources/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.Cources
                .FirstOrDefaultAsync(m => m.Id == id);
            //cource.Owner = await _context.Users.FirstOrDefaultAsync(u=>u.Id == cource.OwnerId);
            //cource.Lessons =  _context.Lessons.Where(u => u.Cource.Id == id && !u.IsDeleted).ToList();
            //var studentsList = _context.Students.Where(s => s.CourceId == id).Select(s => s.StudentId).ToArray();
            //cource.Students = _userManager.Users.Where(u => studentsList.Contains(u.Id)).ToList();

            foreach (var lesson in cource.Lessons)
            {
                lesson.Marks = await _context.Grades.Where(l => l.LessonId == lesson.Id && !lesson.IsDeleted).ToListAsync();
                    
            }

            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

        public async Task<IActionResult> UpdateMark(string markId)
        {
           var grade = await _context.Grades.FirstOrDefaultAsync(g => g.Id == markId);  
           return View(grade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMark(Grade grade)
        {
            var value = grade.Points;
            grade = _context.Grades.FirstOrDefaultAsync(g => g.Id == grade.Id).Result;
            grade.Points = value;
            if (ModelState.IsValid)
            {
                _context.Update(grade);
                await _context.SaveChangesAsync();
                grade.Lesson = _context.Lessons.FirstOrDefault(l => l.Id == grade.LessonId && !l.IsDeleted);
                return RedirectToAction("Details", "Cources", new { Id = 2/* grade.Lesson.Cource.Id*/ });
            }


            return View(grade);
        }



        // GET: Cources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cource cource)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            cource.Owner = applicationUser;
            cource.OwnerId = applicationUser.Id;
            cource.CreationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(cource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cource);
        }

        // GET: Cources/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.Cources.FindAsync(id);
            if (cource == null)
            {
                return NotFound();
            }
            return View(cource);
        }

        // POST: Cources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,  Cource cource)
        {
            if (id != cource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
                    cource.Owner = applicationUser;
                    cource.OwnerId = applicationUser.Id;
                    _context.Update(cource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourceExists(cource.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cource);
        }

        // GET: Cources/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.Cources
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

        // POST: Cources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cource = await _context.Cources.FindAsync(id);
            cource.IsDeleted = true;
            _context.Cources.Update(cource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourceExists(string id)
        {
            return _context.Cources.Any(e => e.Id == id);
        }
    }
}
