using System;
using System.Linq;
using PurchasingSystemServices.Data;
using PurchasingSystemServices.Models;

namespace PurchasingSystemServices.Services
{
    public class GenerateDocNo : IGenerateDocNo
    {
        private DataContext _context = null;

        public GenerateDocNo(DataContext context)
        {
            _context = context;
        }

        public string GetOrderNumber(string code, int currentUserId)
        {
            DocumentNumber orderNumber = new DocumentNumber();
            string ordNumberStr = "";
            string formatCurrentDate = DateTime.Now.ToString("ddMMyyyy");

            orderNumber.Code = _context
                    .DocumentNumbers
                    .Where(u => u.Code == code)
                    .Select(u => u.Code)
                    .SingleOrDefault();

            orderNumber.CurrentSequence = _context
                    .DocumentNumbers
                    .Where(u => u.Code == code)
                    .Select(u => u.CurrentSequence)
                    .SingleOrDefault();

            ordNumberStr = orderNumber.Code + "-" + formatCurrentDate + "-" + orderNumber.CurrentSequence.ToString();

            UpdateDocSeqNumber(orderNumber.CurrentSequence, code, currentUserId);

            return ordNumberStr;
        }

        public string GetInvoiceNumber(string code, int currentUserId)
        {
            DocumentNumber invoiceNumber = new DocumentNumber();
            string invNumberStr = "";
            string formatCurrentDate = DateTime.Now.ToString("ddMMyyyy");

            invoiceNumber.Code = _context
                    .DocumentNumbers
                    .Where(u => u.Code == code)
                    .Select(u => u.Code)
                    .SingleOrDefault();

            invoiceNumber.CurrentSequence = _context
                    .DocumentNumbers
                    .Where(u => u.Code == code)
                    .Select(u => u.CurrentSequence)
                    .SingleOrDefault();

            invNumberStr = invoiceNumber.Code + "-" + formatCurrentDate + "-" + invoiceNumber.CurrentSequence.ToString();

            UpdateDocSeqNumber(invoiceNumber.CurrentSequence, code, currentUserId);

            return invNumberStr;
        }

        public void UpdateDocSeqNumber(int currentSeq, string code, int currentUserId)
        {
            var obj = _context.DocumentNumbers.SingleOrDefault(item => item.Code == code);
            if (obj != null)
            {
                obj.CurrentSequence = currentSeq + 1;
                obj.UpdateBy = currentUserId;
                obj.UpdateDate = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}