
using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooManagement.Models.Response;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;



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

    [HttpGet("Search")]
    public ActionResult<AnimalListResponse> Search([FromQuery] AnimalSearchRequest searchRequest)
    {
        var animals = _animals.Search(searchRequest);
        var animalCount = animals.Count();
        return AnimalListResponse.Create(searchRequest, animals, animalCount);
    }


}