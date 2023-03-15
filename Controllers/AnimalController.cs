using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;
using ZooManagement.Models.Response;


namespace ZooManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IAnimalRepo _animals;

    public AnimalController(IAnimalRepo animals)
    {
        _animals = animals;
    }

    [HttpPost("AddAnimal")]
    public IActionResult AddAnimal([FromBody] AddAnimalRequest animalRequest)
    {
        var response = _animals.CreateAnimal(animalRequest);
        return Ok(response);
    }
    [HttpGet("api/get-animal/{id}")]
    public ActionResult<AnimalResponse> GetById([FromRoute] int id)
    {
        var animal = _animals.GetById(id);
        return Ok(new AnimalResponse(animal));
    }

}