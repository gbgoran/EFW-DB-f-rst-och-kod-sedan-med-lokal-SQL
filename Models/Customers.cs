using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Issues = new HashSet<Issues>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string ContactNameFullName { get; set; }
        public int ContactNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [InverseProperty("FkCustomer")]
        public virtual ICollection<Issues> Issues { get; set; }
    }
}
