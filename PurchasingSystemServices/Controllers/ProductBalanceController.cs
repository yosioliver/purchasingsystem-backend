using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchasingSystemServices.Data;
using PurchasingSystemServices.Models;

namespace PurchasingSystemServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBalanceController : ControllerBase
    {
        private DataContext _context = null;

        public ProductBalanceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public ActionResult GetProductBalanceData()
        {
            List<Product> productList = (from u in _context.Products where u.ProductParentId == 1 select u).ToList();

            return Ok(new { result = productList });
        }

        [HttpPut]
        [EnableCors("AllowOrigin")]
        public ActionResult TopupBalanceToUser(int currentUserId, Int64 balanceAmount)
        {
            try
            {
                //var user = _context.UserBalances.First(a => a.UserId == currentId);

                try
                {
                    var userBalance = _context.UserBalances.First(a => a.UserId == currentUserId);

                    userBalance.BalanceAmount += balanceAmount;
                    userBalance.UpdateBy = currentUserId;
                    userBalance.UpdateDate = DateTime.Now;
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