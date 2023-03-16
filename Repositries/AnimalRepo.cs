using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Text;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace ZooManagement.Repositories
{
    public interface IAnimalRepo
    {
        Animal CreateAnimal(AddAnimalRequest animalRequest);
        Animal GetById(int id);
        IEnumerable<Animal> Search(AnimalSearchRequest search);

    }

    public class AnimalRepo : IAnimalRepo
    {
        private readonly ZooManagementDbContext _context;
        public AnimalRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        public Animal CreateAnimal(AddAnimalRequest animalRequest)
        {
            Animal newAnimal = new Animal
            {
                SpeciesId = animalRequest.SpeciesId,
                Name = animalRequest.Name,
                Sex = animalRequest.Sex,
                DateOfBirth = DateOnly.FromDateTime(DateTime.ParseExact(animalRequest.DateOfBirth, "ddMMyyyy", CultureInfo.InvariantCulture)),
                DateAcquired = DateOnly.FromDateTime(DateTime.ParseExact(animalRequest.DateAcquired, "ddMMyyyy", CultureInfo.InvariantCulture)),
            };
            var insertResponse = _context.Animal.Add(newAnimal);
            _context.SaveChanges();
            return insertResponse.Entity;
        }
        public Animal GetById(int id)
        {
            return _context.Animal
                        .Single(animal => animal.Id == id);
        }

        public IEnumerable<Animal> Search(AnimalSearchRequest search)
        {
            IEnumerable<Animal> animalInfo = _context.Animal.Include(s => s.Species);
            int requiredYear = 0;

            if (search.Age != null)
            {
                requiredYear = (int)(DateTime.Today.Year - search.Age);
            }
            // if (search.OrderByValue != null)
            // {
            //     animalInfo = animalInfo.OrderBy(a => a.GetType().GetProperty(search.OrderByValue).GetValue(a));
            // }
            // else if (search.OrderByValue != null)
            // {
            //     animalInfo = animalInfo.OrderBy(a => a.GetType().GetProperty(search.OrderByValue).GetValue(a));
            // }
            // else
            // {
            //     animalInfo = animalInfo.OrderBy(a => a.Species.SpeciesName);
            // }
            return _context.Animal.Include(s => s.Species)
                .OrderBy(a => a.Species.SpeciesName)
                .Where(a => search.Classification == null || a.Species.Classification == search.Classification)
                .Where(a => search.SpeciesName == null || a.Species.SpeciesName == search.SpeciesName)
                .Where(a => search.Name == null || a.Name == search.Name)
                .Where(a => search.Age == null || a.DateOfBirth.Year == requiredYear)
                .Where(a => search.DateAcquired == null || a.DateAcquired == search.DateAcquired)
                .Where(a => search.SpeciesId == null || a.SpeciesId == search.SpeciesId)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }

    }
}