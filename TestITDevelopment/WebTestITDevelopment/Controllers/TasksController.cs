using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTestITDevelopment.Data;
using WebTestITDevelopment.Models;

namespace WebTestITDevelopment.Controllers
{
    public class TasksController : Controller
    {
        private readonly MvcTaskContext _context;

        public TasksController(MvcTaskContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index(string projectOfTask, string searchString)
        {
            IQueryable<string> project = from m in _context.TaskDB
                                            orderby m.NameProject
                                            select m.NameProject;

            var task = from m in _context.TaskDB
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                task = task.Where(s => s.NameTask.Contains(searchString));            
            }

            if (!string.IsNullOrEmpty(projectOfTask))
            {
                task = task.Where(x => x.NameProject == projectOfTask);
            }

            var projectOfTaskVM = new ProjectOfTaskViewModel
            {
                Project = new SelectList(await project.Distinct().ToListAsync()),
                TaskList = await task.ToListAsync()
            };

            return View(projectOfTaskVM);
        }


        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.TaskDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }


        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameProject,Times,startTimes,endTimes,NameTask,Comment,DataCreate")] TaskNote task)
        {
            if (ModelState.IsValid)
            {
                task.Times = Convert.ToDateTime(task.EndTimes.Subtract(task.StartTimes).ToString());
                task.DataCreate = DateTime.Now;
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.TaskDB.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameProject,Times,startTimes,endTimes,NameTask,Comment,DataCreate")] TaskNote task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
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
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.TaskDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.TaskDB.FindAsync(id);
            _context.TaskDB.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.TaskDB.Any(e => e.Id == id);
        }
    }
}
