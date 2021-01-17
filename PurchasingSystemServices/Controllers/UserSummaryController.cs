using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PurchasingSystemServices.Data;
using PurchasingSystemServices.Models;

namespace PurchasingSystemServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSummaryController : Controller
    {
        private DataContext _context = null;

        public UserSummaryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult GetUsers()
        {
            var count = (from usr in _context.Users
                         select usr).Count();

            return Ok(new { result = count });
        }
    }
}