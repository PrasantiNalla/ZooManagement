using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Text;

namespace ZooManagement.Repositories
{
    public interface ISpeciesRepo
    {
        Species CreateSpecies(AddSpeciesRequest speciesRequest);
        Species GetSpeciesById(int id);
    }

    public class SpeciesRepo : ISpeciesRepo
    {
        private readonly ZooManagementDbContext _context;
        public SpeciesRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        public Species CreateSpecies(AddSpeciesRequest speciesRequest)
        {
            Species newSpecies = new Species
            {
                SpeciesName = speciesRequest.SpeciesName,
                Classification = speciesRequest.Classification

            };
            var insertResponse = _context.Species.Add(newSpecies);
            _context.SaveChanges();
            return insertResponse.Entity;
        }
        public Species GetSpeciesById(int speciesId)
        {//use .include to get the count, use .select and pass in SpeciesResponse
            return _context.Species
                   .Single(x => x.Id == speciesId);
        }

    }
}