using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookFlight.Model;
using BookFlight.Data;

namespace BookFlight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // PUT: api/Profile/{email}
        [HttpPut("{email}")]
        public IActionResult UpdateUserProfile(string email, [FromBody] UserModel updatedUser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.EmailAddress == email);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Update properties
            existingUser.UserName = updatedUser.UserName;
            existingUser.EmailAddress = updatedUser.EmailAddress;
            existingUser.Password = updatedUser.Password;
            // You can update other properties as needed

            // Save changes
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating profile.");
            }

            return Ok("Profile updated successfully");
        }
    }
}
