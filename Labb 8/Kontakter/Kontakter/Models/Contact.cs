using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Kontakter.Models
{
    public class Contact
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Namn måste anges")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Namnet måste vara 3-50 tkn")]      
        [DisplayName("Namn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Efternamn måste anges")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Efternamn måste vara mellan 3-50 tkn")]
        [DisplayName("Efternamn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ange en giltig email")]
        [DisplayName("Email")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Email måste innehålla mer än 3 tecken")]
        [DisplayFormat(DataFormatString = "{0:}")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage="Du måste ange en giltig email-adress")]
        public string Email { get; set; }

        public Contact()
        {
            Id = Guid.NewGuid();
        }
    }
}