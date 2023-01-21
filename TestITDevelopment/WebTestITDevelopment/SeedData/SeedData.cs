using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebTestITDevelopment.Data;

namespace WebTestITDevelopment.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcTaskContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTaskContext>>()))
            {
                // Look for any movies.
                if (context.TaskDB.Any())
                {
                    return;   // DB has been seeded
                }

                context.TaskDB.AddRange(
                    new TaskNote
                    {
                        NameProject = "Учеба",
                        Times = DateTime.Parse("2023-6-12"),
                        StartTimes = DateTime.Parse("2023-6-12"),
                        EndTimes = DateTime.Parse("2023-6-12"),
                        NameTask = "Изучение алгоритмов",
                        Comment = "Прочитать книгу по способам оценки алгоритмов",
                        DataCreate = DateTime.Now,
                    },

                    new TaskNote
                    {
                        NameProject = "Учеба",
                        Times = DateTime.Parse("2023-7-12"),
                        StartTimes = DateTime.Parse("2023-7-12"),
                        EndTimes = DateTime.Parse("2023-7-12"),
                        NameTask = "Изучение тестирование",
                        Comment = "Прочитать книгу по юнит-тестированию",
                        DataCreate = DateTime.Now,
                    },

                    new TaskNote
                    {
                        NameProject = "Учеба",
                        Times = DateTime.Parse("2023-4-12"),
                        StartTimes = DateTime.Parse("2023-4-12"),
                        EndTimes = DateTime.Parse("2023-4-12"),
                        NameTask = "Изучение веб-разработки",
                        Comment = "Изучить 3 книги по веб-разработке на C#",
                        DataCreate = DateTime.Now,
                    },

                    new TaskNote
                    {
                        NameProject = "Работа",
                        Times = DateTime.Parse("2023-4-12"),
                        StartTimes = DateTime.Parse("2023-4-12"),
                        EndTimes = DateTime.Parse("2023-4-12"),
                        NameTask = "Изучение веб-разработки",
                        Comment = "Реализовать проект на C#",
                        DataCreate = DateTime.Now,
                    },

                    new TaskNote
                    {
                        NameProject = "Работа",
                        Times = DateTime.Parse("2023-4-12"),
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
