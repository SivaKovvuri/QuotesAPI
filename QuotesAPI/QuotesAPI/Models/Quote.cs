using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotesAPI.Models
{
    public partial class Quote
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength =5,ErrorMessage ="Check Length")]        
        public string Title { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Check Length")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string QuoteType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
