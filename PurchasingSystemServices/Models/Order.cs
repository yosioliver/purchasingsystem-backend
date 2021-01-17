using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingSystemServices.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_number")]
        [Required]
        [MaxLength(50)]
        public string OrderNumber { get; set; }
        [Column("order_date")]
        [Required]
        public DateTime OrderDate { get; set; }
        [Column("user_id")]
        [Required]
        public int UserId { get; set; }
        [Column("invoice_number")]
        [Required]
        [MaxLength(50)]
        public string InvoiceNumber { get; set; }
        [Column("order_status")]
        [Required]
        public string OrderStatus { get; set; }
        [Column("grand_total")]
        [Required]
        public Int64 GrandTotal { get; set; }

        [Column("create_by")]
        public int CreateBy { get; set; }
        [Column("create_date")]
        public DateTime CreateDate { get; set; }
        [Column("update_by")]
        public int? UpdateBy { get; set; }
        [Column("update_date")]
        public DateTime? UpdateDate { get; set; }
    }
}
