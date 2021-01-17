using System;
namespace PurchasingSystemServices.DTO
{
    public class OrderData
    {
        public Int64 GrandTotal { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int OrderQuantity { get; set; }
        public Int64 SubTotal { get; set; }
    }
}
