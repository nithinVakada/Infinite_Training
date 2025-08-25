using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Assignment1.Models
{
    public class Contact
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}