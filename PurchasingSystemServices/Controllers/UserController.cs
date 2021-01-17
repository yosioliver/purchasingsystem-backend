using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using PurchasingSystemServices.Data;
using PurchasingSystemServices.Models;
using PurchasingSystemServices.Services;

namespace PurchasingSystemServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DataContext _context = null;
        private readonly IPasswordHash passwordHash;

        public UserController(DataContext context, IPasswordHash passwordHash)
        {
            _context = context;
            this.passwordHash = passwordHash;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult GetUsers()
        {
            List<User> userList = _context.Users.ToList();

            return Ok(new { result = userList });
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public ActionResult AuthenticateUser([FromBody] JsonElement body)
        {
            User resultValue = new User();

            string json = JsonSerializer.Serialize(body);

            var userObejct = JsonSerializer.Deserialize<User>(json);

            if (_context.Users.Any(o => o.Email == userObejct.Email))
            {
                resultValue.Password = _context
                    .Users
                    .Where(u => u.Email == userObejct.Email)
                    .Select(u => u.Password)
                    .SingleOrDefault();

                resultValue.UserRole = _context
                    .Users
                    .Where(u => u.Email == userObejct.Email)
                    .Select(u => u.UserRole)
                    .SingleOrDefault();

                resultValue.Name = _context
                    .Users
                    .Where(u => u.Email == userObejct.Email)
                    .Select(u => u.Name)
                    .SingleOrDefault();

                resultValue.Id = _context
                    .Users
                    .Where(u => u.Email == userObejct.Email)
                    .Select(u => u.Id)
                    .SingleOrDefault();

                var isValid = passwordHash.VerifyPassword(resultValue.Password, userObejct.Password);

                if (isValid)
                {
                    _ = resultValue;
                }
                else
                {
                    resultValue = null;
                }
            }
            else
            {
                resultValue = null;
            }

            return Ok(new { result = resultValue });
        }
    }
}