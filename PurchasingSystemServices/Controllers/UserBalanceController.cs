using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PurchasingSystemServices.Data;

namespace PurchasingSystemServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBalanceController : ControllerBase
    {
        private DataContext _context = null;

        public UserBalanceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult GetUsersBalance(int currentId)
        {
            var user = _context.UserBalances.First(a => a.UserId == currentId);

            return Ok(new { result = user.BalanceAmount });
        }
    }
}