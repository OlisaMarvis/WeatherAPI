using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WeatherApp.Persistence.AppContext;

namespace WeatherApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly IWeatherAppDBContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<SetupController> _logger;

        public SetupController(IWeatherAppDBContext context, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, ILogger<SetupController> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Role name is required");
            }

            var roleExists = await _roleManager.RoleExistsAsync(name);
            //check if role exists
            if (roleExists)
            {
                return BadRequest($"Role {name} already exists");
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(name));
            //We need to check if the role has been added successfully
            if (result.Succeeded)
            {
                _logger.LogInformation($"Role {name} created successfully");
                return Ok(new
                {
                    result = $"The role {name} has been added successfully"
                });
            } else
            {
                _logger.LogInformation($"Role {name} has not been added");
                return BadRequest(new
                {
                    error = $"The role {name} has not been added"
                });
            }
           
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string rolename)
        {
            //Check if the user exist
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new {
                    error = "User does not exist"
                });
            }

            //check if the role exist
            var roleExists = await _roleManager.RoleExistsAsync(rolename);
            if (!roleExists)
            {
                _logger.LogInformation($"The role with the {email} does not exist");
                return BadRequest(new
                {
                    error = "Role does not exist"
                });
            }

            var result = await _userManager.AddToRoleAsync(user, rolename);
            //We need to check if the role has been added successfully
            if (result.Succeeded)
            {
                _logger.LogInformation($"User {email} has been added to role {rolename} successfully");
                return Ok(new
                {
                    result = $"The user {email} has been added to role {rolename} successfully"
                });
            }
            else
            {
                _logger.LogInformation($"User {email} has not been added to role {rolename}");
                return BadRequest(new
                {
                    error = $"The user {email} has not been added to role {rolename}"
                });
            }
        }

        [HttpGet]
        [Route("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            //Check if the user exist
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new
                {
                    error = "User does not exist"
                });
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            return Ok(userRoles);
        }


        [HttpPost]
        [Route("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string rolename)
        {
            //Check if the user exist
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new
                {
                    error = "User does not exist"
                });
            }

            //check if the role exist
            var roleExists = await _roleManager.RoleExistsAsync(rolename);
            if (!roleExists)
            {
                _logger.LogInformation($"The role with the {email} does not exist");
                return BadRequest(new
                {
                    error = "Role does not exist"
                });
            }

            var result = await _userManager.RemoveFromRoleAsync(user, rolename);
            //We need to check if the role has been added successfully
            if (result.Succeeded)
            {
                _logger.LogInformation($"User {email} has been removed from role {rolename} successfully");
                return Ok(new
                {
                    result = $"The user {email} has been removed from role {rolename} successfully"
                });
            }
            else
            {
                _logger.LogInformation($"Unable to remove user {email} from role {rolename}");
                return BadRequest(new
                {
                    error = $"Unable to remove user {email} from role {rolename}"
                });
            }
                 
        }

    }
}
