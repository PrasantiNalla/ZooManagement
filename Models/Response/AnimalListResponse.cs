using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Models.Response
{
    public class AnimalListResponse : ListResponse<AnimalResponse>
    {
        private readonly List<Animal> _animals;

        private AnimalListResponse(SearchRequest search, IEnumerable<AnimalResponse> items, int totalNumberOfItems)
            : base(search, items, totalNumberOfItems, "animals") { }

        public static AnimalListResponse Create(SearchRequest search, IEnumerable<Animal> animals, int totalNumberOfItems)
        {
            var animalModels = animals.Select(animal => new AnimalResponse(animal));
            return new AnimalListResponse(search, animalModels, totalNumberOfItems);
        }
    }
}