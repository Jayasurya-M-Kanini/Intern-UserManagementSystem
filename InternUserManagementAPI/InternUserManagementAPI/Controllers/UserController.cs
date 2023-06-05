using InternUserManagementAPI.Interfaces;
using InternUserManagementAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternUserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IManageUser _manageUser;

        public UserController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(InternDTO intern)
        {
            var result = await _manageUser.Register(intern);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to register at this moment");
        }
    }
}
