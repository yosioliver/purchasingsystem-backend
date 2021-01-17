using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PurchasingSystemServices.Data;

namespace PurchasingSystemServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTransactionDetailController : Controller
    {
        private DataContext _context = null;

        public UserTransactionDetailController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult GetUserTransaction(string orderNumber)
        {
            //List<Order> orderList = (from u in _context.Orders where u.UserId == userId select u).ToList();

            var orderDetail = _context.Orders
            .Join(_context.OrderDetails,
                ord => ord.OrderNumber,
                ordDet => ordDet.OrderNumber,
                (ord, ordDet) => new
                {
                    OrderNumber = ord.OrderNumber,
                    GrandTotal = ord.GrandTotal,
                    ItemName = ordDet.ItemName,
                    OrderQuantity = ordDet.OrderQuantity
            }).
            Where(orderDetail => orderDetail.OrderNumber == orderNumber).FirstOrDefault();

            return Ok(new { result = orderDetail });
        }
    }
}