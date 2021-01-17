using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingSystemServices.Models
{
    [Table("user_balance")]
    public class UserBalance
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        [Required]
        public int UserId { get; set; }
        [Column("balance_amount")]
        [Required]
        public Int64 BalanceAmount { get; set; }
        [Column("active", TypeName = "char")]
        [Required(AllowEmptyStrings = false)]
        public int Active { get; set; }

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
