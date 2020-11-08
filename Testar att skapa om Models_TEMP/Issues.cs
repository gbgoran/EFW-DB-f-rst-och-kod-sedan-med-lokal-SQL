using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    public partial class Issues
    {
        public Issues()
        {
            Comments = new HashSet<Comments>();
        }

        [Key]
        [Column("IssueID")]
        public int IssueId { get; set; }
        [Column("FK_CustomerID")]
        public int FkCustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        [ForeignKey(nameof(FkCustomerId))]
        [InverseProperty(nameof(Customers.Issues))]
        public virtual Customers FkCustomer { get; set; }
        [InverseProperty("FkIssue")]
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
