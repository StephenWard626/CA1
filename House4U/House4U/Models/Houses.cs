using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace House4U.Models
{
    public enum LeaseType
    {
        Managed, Delegated
    }
    public class Houses
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Address { get; set; }
        [Range (1,100,ErrorMessage ="Property must have at least 1 bedroom.")]
        public int Bedrooms { get; set; }
        [Required]
        public LeaseType Lease { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="That is not a valid emails address.")]
        public string Email { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }

    }
}
