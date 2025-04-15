using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudySync.Dtos;
using StudySync.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudySync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelDTO model)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Step 1: Check whether the user exists or not
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if(userExists != null)
            {
                return BadRequest(new { message = "User already exists" });
            }

            // Step 2: Mapp DTO to ApplicationUser
            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email
            };

            // Step 3: Create an instance of the user in the Database
            var result = await _userManager.CreateAsync(user, model.Password);

            if(!result.Succeeded)
            {
                return BadRequest(new { message = "User creation failed" });
            }



            var roleExists = await _roleManager.RoleExistsAsync("Admin");
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            await _userManager.AddToRoleAsync(user, "Admin");

            return Ok(new {Status = "Success", Message = "User created successfully" });


            //if (ModelState.IsValid)
            //{
            //    var user = new ApplicationUser
            //    {
            //        UserName = model.Email,
            //        Email = model.Email
            //    };
            //    var result = await _userManager.CreateAsync(user, model.Password);
            //    if (result.Succeeded)
            //    {
            //        return Ok(new { message = "User registered successfully" });
            //    }
            //    return BadRequest(result.Errors);
            //}
            //return BadRequest(ModelState);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDTO model)
        {
            // Step 1: Check whether the user exists or not
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { message = "User does not exist" });
            }
            // Step 2: Check whether the password is correct or not
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                return BadRequest(new { message = "Incorrect password" });
            }
            // Step 3: Generate a lit of claims for the user (this username and a unique identifier JTI)

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            // Add roles to claims
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Step 4: Create a JWT signing key from the key in our app settings
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Step 5: Create a JWT token with: issuer, audience, claims, expiration time, and signing credentials
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );



            // Step 6: Return the token to the client
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                //userId = user.Id
            });

        }


        // Defining a role for Role-Based-Authorization
        [HttpPost("role")]
        public async Task<IActionResult> CreateRole(string role) 
        {
            var roleExists = await _roleManager.RoleExistsAsync(role);

            if (!roleExists)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole("Admin"));
                if(result.Succeeded)
                {
                    return Ok(new { message = "Role created successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Role creation failed" });
                }

            }

            return BadRequest(new { message = "Role already exists" });

        }


        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRoleToUser(UserRoleAssingmentDTO roleAssingmentDTO) 
        {

            if (roleAssingmentDTO == null)
            {
                return BadRequest(new { message = "Invalid role assignment data" });
            }

            var userExists = await _userManager.FindByIdAsync(roleAssingmentDTO.UserId);
            
            if (userExists == null)
            {
                return BadRequest(new { message = "User does not exist" });
            }
            var roleExists = await _roleManager.RoleExistsAsync(roleAssingmentDTO.RoleName);

            if (!roleExists)
            {
                return BadRequest(new { message = "Role does not exist" });
            }

            if (await _userManager.IsInRoleAsync(userExists, roleAssingmentDTO.RoleName))
            {
                return BadRequest(new { message = "User is already in this role" });
            }


            var result = await _userManager.AddToRoleAsync(userExists, roleAssingmentDTO.RoleName);

            if (result.Succeeded)
            {
                return Ok(new { message = "Role assigned successfully" });
            }
            else
            {
                return BadRequest(new { message = "Role assignment failed" });
            }


        }







    }
}
