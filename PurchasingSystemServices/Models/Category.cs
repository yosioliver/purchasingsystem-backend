using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingSystemServices.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Column("level")]
        [Required]
        public int Level { get; set; }
        [Column("parent_id")]
        [Required]
        public int ParentId { get; set; }
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
