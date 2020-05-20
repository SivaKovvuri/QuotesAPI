using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Data;
using QuotesAPI.Models;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {

        private QuotesDbContext _quotesDbContext;

        public QuotesController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }

        // GET: api/Quotes
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotesDbContext.Quote;
        }

        // GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public Quote Get(int id)
        {
            var quote = _quotesDbContext.Quote.Find(id);
            return quote;
        }

        // POST: api/Quotes
        [HttpPost]
        public void Post([FromBody] Quote quote)
        {
            _quotesDbContext.Quote.Add(quote);
            _quotesDbContext.SaveChanges();
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quote quote)
        {
            var entity = _quotesDbContext.Quote.Find(id);
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            _quotesDbContext.SaveChanges();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = _quotesDbContext.Quote.Find(id);
            _quotesDbContext.Quote.Remove(entity);
            _quotesDbContext.SaveChanges();
        }
    }
}
