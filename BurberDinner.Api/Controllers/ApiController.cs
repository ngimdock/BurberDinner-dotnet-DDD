
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurberDinner.Api.Controllers;


[ApiController]
[Authorize]
public class ApiController: ControllerBase {

}