using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
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
    public class UserManagementController : ControllerBase
    {
        private DataContext _context = null;
        private readonly IPasswordHash passwordHash;

        public UserManagementController(DataContext context, IPasswordHash passwordHash)
        {
            _context = context;
            this.passwordHash = passwordHash;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult Get(int idUser)
        {
            var userData = _context.Users.Single(p => p.Id == idUser);

            return Ok(new { result = userData });
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public ActionResult CreateUser([FromBody] JsonElement body)
        {
            string json = JsonSerializer.Serialize(body);

            var userObejct = JsonSerializer.Deserialize<User>(json);

            var hashedPassword = passwordHash.HashPassword(userObejct.Password, null, false);

            var newUser = new User()
            {
                Email = userObejct.Email,
                Name = userObejct.Name,
                Phone = userObejct.Phone,
                UserRole = "U",
                Password = hashedPassword,
                CreateBy = 1,
                CreateDate = DateTime.Now,
                Active = 1
            };

            try
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();

                int maxId = _context.Users.Max(p => p.Id);

                var newUserBalance = new UserBalance()
                {
                    UserId = maxId,
                    BalanceAmount = 0,
                    Active = 1,
                    CreateBy = 1,
                    CreateDate = DateTime.Now
                };

                _context.UserBalances.Add(newUserBalance);
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

        [HttpPut]
        [EnableCors("AllowOrigin")]
        public ActionResult UpdateUser(int currentId, int userId, [FromBody] JsonElement body)
        {
            string json = JsonSerializer.Serialize(body);

            var userObejct = JsonSerializer.Deserialize<User>(json);

            var hashedPassword = passwordHash.HashPassword(userObejct.Password, null, false);

            User resultValue = new User();

            resultValue.UserRole = _context
                    .Users
                    .Where(u => u.Id == currentId)
                    .Select(u => u.UserRole)
                    .SingleOrDefault();

            try
            {
                var user = _context.Users.First(a => a.Id == userId);
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

        [HttpDelete]
        [EnableCors("AllowOrigin")]
        public ActionResult DeleteUser(int userId)
        {
            try
            {
                var user = _context.Users.First(a => a.Id == userId);
                _context.Users.Remove(user);
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