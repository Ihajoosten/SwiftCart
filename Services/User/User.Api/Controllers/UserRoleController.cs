using Microsoft.AspNetCore.Mvc;
using User.Application.Dto.UserRole;
using User.Application.Interfaces;

namespace User.Api.Controllers
{
    [ApiController]
    [Route("api/user-roles")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleAppService _userRoleService;

        public UserRoleController(IUserRoleAppService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost]
        public async Task<IActionResult?> AddUserToRole([FromBody] CreateUserRoleDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdRole = await _userRoleService.AddUserToRoleAsync(createDto.UserId, createDto.RoleId); ;
                return CreatedAtAction("New User Role Created!", createdRole);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{userId}/{roleId}")]
        public async Task<IActionResult?> RemoveUserFromRole(int userId, int roleId)
        {
            try
            {
                var deletedOrder = await _userRoleService.RemoveUserFromRoleAsync(userId, roleId);
                if (!deletedOrder)
                {
                    return StatusCode(422, "Could Not Delete User Role - Unprocessable Content");
                }

                return Ok(deletedOrder);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult?> GetRolesForUser(int userId)
        {
            try
            {
                var roles = await _userRoleService.GetRolesForUserAsync(userId);
                if (roles == null || !roles.Any())
                {
                    return NotFound();
                }
                return Ok(roles);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("role/{roleName}")]
        public async Task<IActionResult?> GetUsersInRole(string roleName)
        {
            try
            {
                var users = await _userRoleService.GetUsersInRoleAsync(roleName);
                if (users == null || !users.Any())
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
