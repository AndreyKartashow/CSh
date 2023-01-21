using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcNote.Data;
using MvcNote.Models;

namespace MvcNote.Controllers
{
    public class NotesController : Controller
    {
        private readonly MvcNoteContext _context;

        public NotesController(MvcNoteContext context)
        {
            _context = context;
        }

        // GET: Notes
        public async Task<IActionResult> Index(string projectName, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Note
                                            orderby m.NameProject
                                            select m.NameProject;

            var notes = from m in _context.Note
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                notes = notes.Where(s => s.Comment.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(projectName))
            {
                notes = notes.Where(x => x.NameProject == projectName);
            }

            var projectNote = new NoteProjectViewModel
            {
                Projects = new SelectList(await genreQuery.Distinct().ToListAsync()),
                ListNote = await notes.ToListAsync()
            };

            return View(projectNote);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameProject,Times,StartTimes,EndTimes,NameTask,Comment,DataCreate")] Note note)
        {
            if (ModelState.IsValid)
            {
                note.DataCreate = DateTime.Now;
                if (note.EndTimes > note.StartTimes)
                {
                    int hours = Convert.ToInt32(Math.Floor((note.EndTimes.Subtract(note.StartTimes).TotalMinutes) / 60));
                    int minutes = Convert.ToInt32((note.EndTimes.Subtract(note.StartTimes).TotalMinutes) - (hours * 60));
                    note.Times =  hours.ToString() + "h" + " : " +  minutes.ToString() + "m" ;

                }
                else 
                {
                    note.Times = "0h : 0m";
                }
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameProject,Times,StartTimes,EndTimes,NameTask,Comment,DataCreate")] Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    note.DataCreate = DateTime.Now;
                    if (note.EndTimes > note.StartTimes)
                    {
                        int hours = Convert.ToInt32 (Math.Floor((note.EndTimes.Subtract(note.StartTimes).TotalMinutes) / 60));
                        int minutes = Convert.ToInt32((note.EndTimes.Subtract(note.StartTimes).TotalMinutes) - (hours * 60));
                        note.Times = hours.ToString() + "h" + " : " + minutes.ToString() + "m";

                    }
                    else
                    {
                        note.Times = "0h : 0m";
                    }
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.Id))
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
            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = await _context.Note
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var note = await _context.Note.FindAsync(id);
            _context.Note.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return _context.Note.Any(e => e.Id == id);
        }
    }
}
