using Microsoft.AspNetCore.Mvc;
using BurberDinner.Contracts.Menus;
using BurberDinner.Api.Controllers;
using MapsterMapper;
using BurberDinner.Application.Menus.Commands.CreateMenu;
using BurberDinner.Domain.Menu;

[Route("/hosts/{hostId}/menus")]
// [AllowAnonymous]
public class MenusController: ApiController {

  private readonly IMapper _mapper;
  private readonly CreateMenuCommandHandler _createMenuCommandHandler;

  public MenusController(
    IMapper mapper,
    CreateMenuCommandHandler createMenuCommandHandler) {

    _mapper = mapper;
    _createMenuCommandHandler = createMenuCommandHandler;
  } 

  [HttpPost]
  public async Task<IActionResult> CreateMenu(
    CreateMenuRequest request,
    string hostId
  ){
    
   CreateMenuCommand command = _mapper.Map<CreateMenuCommand>((request, hostId));

   Menu menu = await _createMenuCommandHandler.Handle(command);
   

  //  MenuResponse menuResponse = _mapper.Map<MenuResponse>(menu);

   return Ok(menu);
  }
}

