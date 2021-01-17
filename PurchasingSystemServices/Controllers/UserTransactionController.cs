using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using PurchasingSystemServices.Data;
using PurchasingSystemServices.DTO;
using PurchasingSystemServices.Models;
using PurchasingSystemServices.Services;

namespace PurchasingSystemServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTransactionController : ControllerBase
    {
        private DataContext _context = null;
        private readonly IGenerateDocNo generateDocNo;

        public UserTransactionController(DataContext context, IGenerateDocNo generateDocNo)
        {
            _context = context;
            this.generateDocNo = generateDocNo;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult GetUserTransaction(int userId)
        {
            List<Order> orderList = (from u in _context.Orders where u.UserId == userId select u).ToList();

            return Ok(new { result = orderList });
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        public ActionResult CreateUserTransaction(int currentUserId, [FromBody]JsonElement OrderData)
        {
            string jsonOrderObj = JsonSerializer.Serialize(OrderData);

            var orderObejct = JsonSerializer.Deserialize<OrderData>(jsonOrderObj);

            var ordNumber = generateDocNo.GetOrderNumber("ORD", currentUserId);
            var invNumber = generateDocNo.GetOrderNumber("INV", currentUserId);

            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newOrder = new Order()
                    {
                        OrderNumber = ordNumber,
                        OrderDate = DateTime.Now,
                        UserId = currentUserId,
                        InvoiceNumber = invNumber,
                        OrderStatus = "PAID",
                        GrandTotal = orderObejct.GrandTotal,
                        CreateBy = currentUserId,
                        CreateDate = DateTime.Now
                    };

                    _context.Orders.Add(newOrder);
                    _context.SaveChanges();

                    var newOrderDetail = new OrderDetail()
                    {
                        OrderNumber = ordNumber,
                        ItemId = orderObejct.ItemId,
                        ItemName = orderObejct.ItemName,
                        OrderQuantity = orderObejct.OrderQuantity,
                        SubTotal = orderObejct.SubTotal,
                        CreateBy = currentUserId,
                        CreateDate = DateTime.Now
                    };

                    _context.OrderDetails.Add(newOrderDetail);
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex.ToString());
                }
            }

            return Ok(new { result = "OK" });
        }
    }
}