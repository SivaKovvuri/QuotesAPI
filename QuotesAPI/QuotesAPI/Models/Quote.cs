﻿using System;
using System.Collections.Generic;

namespace QuotesAPI.Models
{
    public partial class Quote
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string QuoteType { get; set; }
    }
}
