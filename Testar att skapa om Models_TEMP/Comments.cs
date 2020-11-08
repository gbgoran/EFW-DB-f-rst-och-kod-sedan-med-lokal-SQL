using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    public partial class Comments
    {
        [Key]
        [Column("CommentID")]
        public int CommentId { get; set; }
        [Column("FK_IssueID")]
        public int FkIssueId { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [ForeignKey(nameof(FkIssueId))]
        [InverseProperty(nameof(Issues.Comments))]
        public virtual Issues FkIssue { get; set; }
    }
}
