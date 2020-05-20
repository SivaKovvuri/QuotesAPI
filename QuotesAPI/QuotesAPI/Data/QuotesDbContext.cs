using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotesAPI.Models;

namespace QuotesAPI.Data
{
    public class QuotesDbContext:DbContext
    {
        public QuotesDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<QuotesAPI.Models.Quote> Quote { get; set; }
    }
}
