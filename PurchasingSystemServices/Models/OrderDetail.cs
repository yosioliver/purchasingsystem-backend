using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingSystemServices.Models
{
    [Table("order_detail")]
    public class OrderDetail
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_number")]
        [Required]
        [MaxLength(50)]
        public string OrderNumber { get; set; }
        [Column("item_id")]
        [Required]
        public string ItemId { get; set; }
        [Column("item_name")]
        [Required]
        public string ItemName { get; set; }
        [Column("order_quantity")]
        [Required]
        public int OrderQuantity { get; set; }
        [Column("sub_total")]
        [Required]
        public Int64 SubTotal { get; set; }

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
