using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchasingSystemServices.Models
{
    [Table("document_number")]
    public class DocumentNumber
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code", TypeName = "char(3)")]
        [Required(AllowEmptyStrings = false)]
        public string Code { get; set; }
        [Column("current_sequence")]
        [Required]
        public Int32 CurrentSequence { get; set; }

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
