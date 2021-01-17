using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingSystemServices.Models
{
    [Table("user_role")]
    public class UserRole
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code", TypeName = "char")]
        [MaxLength(1)]
        [Required(AllowEmptyStrings = false)]
        public string Code { get; set; }
        [Column("role")]
        public string Role { get; set; }
    }
}
