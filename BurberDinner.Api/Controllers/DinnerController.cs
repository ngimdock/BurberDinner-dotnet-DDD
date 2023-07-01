using Microsoft.AspNetCore.Mvc;
namespace BurberDinner.Api.Controllers;

[Route("[controller]")]
public class DinnerController: ApiController {

  
  [HttpGet]
  public IActionResult ListDinner() {

    Console.WriteLine("Inter here..");

    return Ok(Array.Empty<string>());
  }
}