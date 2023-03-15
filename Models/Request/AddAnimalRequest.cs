namespace ZooManagement.Models.Request
{
    public class AddAnimalRequest
    {

        public int SpeciesId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string DateOfBirth { get; set; }
        public string DateAcquired { get; set; }
    }
}