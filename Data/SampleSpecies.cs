using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Repositories;

namespace ZooManagement.Data
{
    public static class SampleSpecies
    {
        public const int NumberOfSpecies = 5;
        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "Cheetah", "Mammal"},
            new List<string> { "Elephant", "Mammal"},
            new List<string> { "Shark", "Fish"},
            new List<string> { "Flamingo", "Bird"},
            new List<string> { "Dolphins", "Fish"},
        };
        public static IEnumerable<Species> AddAllSpecies()
        {
            return Enumerable.Range(0, NumberOfSpecies).Select(AddSpecies);
        }
        private static Species AddSpecies(int index)
        {
            return new Species
            {
                SpeciesName = Data[index][0],
                Classification = Data[index][1],
            };
        }
    }
}