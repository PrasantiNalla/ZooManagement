namespace ZooManagement.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }

    public class IdSearchRequest : SearchRequest
    {
        public int? SpeciesId { get; set; }
        public override string Filters => SpeciesId == null ? "" : $"&speciesId={SpeciesId}";
    }
    public class AnimalSearchRequest : IdSearchRequest
    {
        public string? Classification { get; set; }
        public string? SpeciesName { get; set; }
        public string? Name { get; set; }
        public DateOnly? DateAcquired { get; set; }
        public int? Age { get; set; }
        public string? OrderByValue { get; set; }
        public override string Filters
        {
            get
            {
                var filters = "";
                if (Classification != null)
                {
                    filters += $"&classification={Classification}";
                }
                if (SpeciesName != null)
                {
                    filters += $"&speciesName={SpeciesName}";
                }
                if (Name != null)
                {
                    filters += $"&name={Name}";
                }
                if (DateAcquired != null)
                {
                    filters += $"&dateAcquired={DateAcquired}";
                }
                if (Age != null)
                {
                    filters += $"&age={Age}";
                }
                if (OrderByValue != null)
                {
                    filters += $"&orderByValue={OrderByValue}";
                }
                return filters;
            }
        }
    }
}