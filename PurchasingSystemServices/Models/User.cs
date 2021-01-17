using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingSystemServices.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Column("email")]
        [Required]
        public string Email { get; set; }
        [Column("password", TypeName = "varchar")]
        [Required]
        public string Password { get; set; }
        [Column("phone", TypeName = "varchar")]
        [Required]
        [MaxLength(14)]
        public string Phone { get; set; }
        [Column("role_code")]
        [Required]
        public string UserRole { get; set; }
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

        public static implicit operator int(User v)
        {
            throw new NotImplementedException();
        }
    }
}
