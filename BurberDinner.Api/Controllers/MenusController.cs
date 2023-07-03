using Microsoft.AspNetCore.Mvc;

using BurberDinner.Contracts.Menus;
using BurberDinner.Api.Controllers;
using Microsoft.AspNetCore.Authorization;

[Route("/hosts/{hostId}/menus")]
// [AllowAnonymous]
public class MenusController: ApiController {

  [HttpPost]
  public IActionResult CreateMenu(
    CreateMenuRequest request,
    string hostId
  ){
   
   
   return Ok(request);
  }
}