using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;
using ZooManagement.Models.Response;


namespace ZooManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class SpeciesController : ControllerBase
{
    private readonly ISpeciesRepo _species;

    public SpeciesController(ISpeciesRepo species)
    {
        _species = species;
    }

    [HttpPost("AddSpecies")]
    public IActionResult AddSpecies([FromBody] AddSpeciesRequest speciesRequest)
    {
        var response = _species.CreateSpecies(speciesRequest);
        return Ok(response);

    }
    [HttpGet("api/get-species/{id}")]
    public ActionResult<SpeciesResponse> GetBySpeciesId([FromRoute] int id)
    {
        var species = _species.GetSpeciesById(id);
        return Ok(new SpeciesResponse(species));
    }

}