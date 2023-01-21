using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcNote.Data;
using System;
using System.Linq;

namespace MvcNote.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcNoteContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcNoteContext>>()))
            {
                // Look for any movies.
                if (context.Note.Any())
                {
                    return;   // DB has been seeded
                }

                context.Note.AddRange(
                    new Note
                    {
                        NameProject = "Учеба",
                        Times = "0h : 0m",
                        StartTimes = DateTime.Parse("2023-6-12"),
                        EndTimes = DateTime.Parse("2023-6-12"),
                        NameTask = "Изучение алгоритмов",
                        Comment = "Прочитать книгу по способам оценки алгоритмов",
                        DataCreate = DateTime.Now,
                    },

                    new Note
                    {
                        NameProject = "Учеба",
                        Times = "0h : 0m",
                        StartTimes = DateTime.Parse("2023-7-12"),
                        EndTimes = DateTime.Parse("2023-7-12"),
                        NameTask = "Изучение тестирование",
                        Comment = "Прочитать книгу по юнит-тестированию",
                        DataCreate = DateTime.Now,
                    },

                    new Note
                    {
                        NameProject = "Учеба",
                        Times = "0h : 0m",
                        StartTimes = DateTime.Parse("2023-4-12"),
                        EndTimes = DateTime.Parse("2023-4-12"),
                        NameTask = "Изучение веб-разработки",
                        Comment = "Изучить 3 книги по веб-разработке на C#",
                        DataCreate = DateTime.Now,
                    },

                    new Note
                    {
                        NameProject = "Работа",
                        Times = "0h : 0m",
                        StartTimes = DateTime.Parse("2023-4-12"),
                        EndTimes = DateTime.Parse("2023-4-12"),
                        NameTask = "Изучение веб-разработки",
                        Comment = "Реализовать проект на C#",
                        DataCreate = DateTime.Now,
                    },

                    new Note
                    {
                        NameProject = "Работа",
                        Times = "0h : 0m",
                        StartTimes = DateTime.Parse("2023-4-12"),
                        EndTimes = DateTime.Parse("2023-4-12"),
                        NameTask = "Изучение верстки",
                        Comment = "Реализовать стилистику проект на CSS",
                        DataCreate = DateTime.Now,
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
