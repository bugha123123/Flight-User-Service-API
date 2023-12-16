using Azure;
using BookFlight.Data;
using BookFlight.Model;
using BookFlight.Model.DBO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookFlight.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

    
        public UserController(ApplicationDbContext context)
        {
            _context = context;

  
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddNewUser(UserModel createUser)
        {
            if (createUser is null)
                return BadRequest(createUser);

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == createUser.EmailAddress);

            if (existingUser != null)
            {
                // A user with the specified email address already exists
                return BadRequest(createUser);
            }

            //TODO--Implement automapper logic here...
            UserModel newCompany = new()
            {
                UserName = createUser.UserName,
                EmailAddress = createUser.EmailAddress,
         
                Password    = createUser.Password
            };
          await  _context.Users.AddAsync(newCompany);
         await   _context.SaveChangesAsync();



            return Created(string.Empty, newCompany);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<UserModel>> GetUsers()
        {
            List<UserModel> users = _context.Users.ToList();

            if (users.Count == 0)
                return NoContent();

            // TODO: Implement automapper logic here...
            List<UserModel> result = users.Select(x => new UserModel
            {
                Id = x.Id,
                UserName = x.UserName,
                EmailAddress = x.EmailAddress,
                Password = x.Password,
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> IsEmailUnique(string email)
        {
            bool isUnique = !_context.Users.Any(user => user.EmailAddress == email);

            return Ok(isUnique);
        }



        [HttpPut]
        public async Task<IActionResult> UpdateUserPassword(UpdateUserDTO user)
        {
            // Find the user by email
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == user.EmailAddress);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            // Change the password
            existingUser.Password = user.Password;

            // Save the changes
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
