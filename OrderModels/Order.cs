using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrderModels
{
    /// <summary>
    /// Represents an Order which can have multiple order items
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Addresses the customer with this name
        /// </summary>
        [Display(Name="Your Name")]
        [Required(ErrorMessage=@"Common, we gotta know who you are!")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Email id where the order notification is to be received
        /// </summary>
        [Display(Name="Email Id")]
        [Required(ErrorMessage= "Your email id please")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$",
            ErrorMessage = @":-( .. Please submit a valid email id")]
        public string EmailId { get; set; }

        /// <summary>
        /// Description of what is needed in this order
        /// </summary>
        [Required(ErrorMessage= @"Won't you enter your order details please?")]
        public string Details { get; set; }

        public string SampleXML { get; set; } 
    }
}