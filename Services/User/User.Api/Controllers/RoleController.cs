using Microsoft.AspNetCore.Mvc;
using User.Application.Dto.Role;
using User.Application.Interfaces;

namespace User.Api.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleAppService _roleService;

        public RoleController(IRoleAppService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _roleService.GetAllAsync();
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

        [HttpGet("{roleId}")]
        public async Task<IActionResult?> GetRole(int roleId)
        {
            try
            {
                var role = await _roleService.GetByIdAsync(roleId);

                if (role == null)
                {
                    return NotFound();
                }

                return Ok(role);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult?> CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdRole = await _roleService.CreateAsync(createRoleDto);
                return CreatedAtAction(nameof(GetRole), new { roleId = createdRole.Id }, createdRole);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult?> UpdateRole(int roleId, [FromBody] UpdateRoleDto updateRoleDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedRole = await _roleService.UpdateAsync(roleId, updateRoleDto);
                if (!updatedRole)
                {
                    return StatusCode(422, "Could Not Update Role - Unprocessable Content");
                }

                return Ok(updatedRole);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult?> DeleteRole(int roleId)
        {
            try
            {
                var deletedRole = await _roleService.DeleteAsync(roleId);
                if (!deletedRole)
                {
                    return StatusCode(422, "Could Not Delete Role - Unprocessable Content");
                }

                return Ok(deletedRole);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
