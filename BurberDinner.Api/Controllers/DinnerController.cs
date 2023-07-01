


using Microsoft.AspNetCore.Mvc;

namespace BurberDinner.Api.Controllers;

[Route("dinners")]
public class DinnerController: ApiController {

  
  [HttpGet()]
  public IActionResult ListDinner() {

    return Ok(Array.Empty<string>());
  }
}