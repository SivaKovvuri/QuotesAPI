using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI.Models;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {

        private QuotesDBContext _quotesDbContext;

        public QuotesController(QuotesDBContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }

        // GET: api/Quotes
        [HttpGet]
        public IActionResult Get(string sort)
        {
            IQueryable<Quote> quote;
            switch (sort)
            {
                case "asc":
                   quote= _quotesDbContext.Quote.OrderBy(x=>x.CreatedDate);
                    break;
                case "desc":
                     quote=_quotesDbContext.Quote.OrderByDescending(x => x.CreatedDate);
                    break;
                default:
                     quote=_quotesDbContext.Quote;
                    break;
            }
            return Ok(quote);
        }


        // GET: api/Quotes
        [HttpGet("[action]")]
        public IActionResult PageQuote(int? pageNumber,int? pageSize)
        {
            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 5;

            IQueryable
                <Quote> quote = _quotesDbContext.Quote.Skip(currentPageNumber - 1).Take(currentPageSize);


            return Ok(quote);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var quote = _quotesDbContext.Quote.Find(id);
            if (quote == null)
            {
                return NotFound("Quote Not Found");
            }
            else { return StatusCode(StatusCodes.Status200OK, quote); }

        }

        // POST: api/Quotes
        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            _quotesDbContext.Quote.Add(quote);
            _quotesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
            var entity = _quotesDbContext.Quote.Find(id);
            if (entity==null)
            {
                return NotFound("Record Not Found!!");
            }
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            entity.QuoteType = quote.QuoteType;
            entity.CreatedDate = quote.CreatedDate;
            _quotesDbContext.SaveChanges();
            return Ok("Record Updated Successfully!!");

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _quotesDbContext.Quote.Find(id);
            if (entity == null)
            {
                return NotFound("Record Not Found!!");
            }
            _quotesDbContext.Quote.Remove(entity);
            _quotesDbContext.SaveChanges();
            return Ok("Record Deleted Successfully!!");

        }
    }
}
