using Studentska_razmjena_API.Data;
using Studentska_razmjena_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Studentska_razmjena_API
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Studenti.Any())
            {
                var students = new List<Student>()
        {
            new Student()
            {
                Ime = "John",
                Prezime = "Doe",
                JMBAG = "1234567890",
                Razmjene = new List<Razmjena>()
                {
                    new Razmjena()
                    {
                        Drzava = "USA",
                        Sveuciliste = "ABC University",
                        DatumOd = new DateTime(2023, 1, 1),
                        DatumDo = new DateTime(2023, 6, 30)
                    },
                    new Razmjena()
                    {
                        Drzava = "Canada",
                        Sveuciliste = "XYZ University",
                        DatumOd = new DateTime(2023, 7, 1),
                        DatumDo = new DateTime(2023, 12, 31)
                    }
                }
            },
            new Student()
            {
                Ime = "Jane",
                Prezime = "Smith",
                JMBAG = "0987654321",
                Razmjene = new List<Razmjena>()
                {
                    new Razmjena()
                    {
                        Drzava = "Germany",
                        Sveuciliste = "LMN University",
                        DatumOd = new DateTime(2023, 3, 1),
                        DatumDo = new DateTime(2023, 8, 31)
                    }
                }
            }
        };

                foreach (var student in students)
                {
                    foreach (var razmjena in student.Razmjene)
                    {
                        razmjena.Student = student; 
                    }
                }

                dataContext.Studenti.AddRange(students);
                dataContext.SaveChanges();
            }
        }
    }
}