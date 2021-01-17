using System;

namespace PurchasingSystemServices.Services
{
    public interface IGenerateDocNo
    {
        public string GetOrderNumber(string code, int currentUserId);
        public string GetInvoiceNumber(string code, int currentUserId);
    }
}
