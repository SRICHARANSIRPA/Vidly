using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribeToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MemberShipId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { set; get; }
    }
     
     
}

