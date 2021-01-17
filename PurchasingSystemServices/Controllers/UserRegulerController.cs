using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchasingSystemServices.Data;
using PurchasingSystemServices.Models;
using PurchasingSystemServices.Services;

namespace PurchasingSystemServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegulerController : ControllerBase
    {
        private DataContext _context = null;
        private readonly IPasswordHash passwordHash;

        public UserRegulerController(DataContext context, IPasswordHash passwordHash)
        {
            _context = context;
            this.passwordHash = passwordHash;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult GetCurrentUserReguler(int idUser)
        {
            User user = (from u in _context.Users where u.Id == idUser && u.UserRole == "U" select u).FirstOrDefault();

            return Ok(new { result = user });
        }

        [HttpPut]
        [EnableCors("AllowOrigin")]
        public ActionResult UpdateUserReguler(int currentId, [FromBody] JsonElement body)
        {
            string json = JsonSerializer.Serialize(body);

            var userObejct = JsonSerializer.Deserialize<User>(json);

            var hashedPassword = passwordHash.HashPassword(userObejct.Password, null, false);

            try
            {
                var user = _context.Users.First(a => a.Id == currentId);
                user.Name = userObejct.Name;
                user.Email = userObejct.Email;
                user.Phone = userObejct.Phone; ;
                user.Password = hashedPassword;
                user.UserRole = user.UserRole;
                user.UpdateBy = currentId;
                user.UpdateDate = DateTime.Now;
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                //This either returns a error string, or null if it can’t handle that error
                if (ex != null)
                {
                    return BadRequest(ex.ToString()); //return the error string
                }
                throw; //couldn’t handle that error, so rethrow
            }

            return Ok(new { result = "OK" });
        }
    }
}