using ZooManagement.Models.Database;

namespace ZooManagement.Models.Response
{
    public class SpeciesResponse
    {
        public int Id { get; set; }
        public string SpeciesName { get; set; }
        public string Classification { get; set; }
        public List<Animal> Animals { get; set; }//use length to get the count 

        public SpeciesResponse(Species species)
        {
            Id = species.Id;
            SpeciesName = species.SpeciesName;
            Classification = species.Classification;
            Animals = species.Animals;
        }

    }
}