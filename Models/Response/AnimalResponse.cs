using ZooManagement.Models.Database;

namespace ZooManagement.Models.Response
{
    public class AnimalResponse
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateAcquired { get; set; }

        public AnimalResponse(Animal animal)
        {
            Id = animal.Id;
            SpeciesId = animal.SpeciesId;
            Name = animal.Name;
            Sex = animal.Sex;
            DateOfBirth = animal.DateOfBirth;
            DateAcquired = animal.DateAcquired;
        }

    }
}