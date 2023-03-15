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

namespace ZooManagement.Repositories
{
    public interface IAnimalRepo
    {
        Animal CreateAnimal(AddAnimalRequest animalRequest);
        Animal GetById(int id);
        IEnumerable<Animal> Search(AnimalSearchRequest search);
        int Count(AnimalSearchRequest search);
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
            return _context.Animal
                .Where(p => search.SpeciesId == null || p.SpeciesId == search.SpeciesId)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }
        public int Count(AnimalSearchRequest search)
        {
            return _context.Animal
                .Count(p => search.SpeciesId == null || p.SpeciesId == search.SpeciesId);
        }
    }
}