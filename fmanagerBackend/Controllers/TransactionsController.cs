using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fmanagerBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace fmanagerBackend.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly TransactionContext _context;

        public TransactionsController(TransactionContext context)
        {
            _context = context;
        }

        // GET api/transactions
        [HttpGet]
        public async Task<string> Get()
        {            var trs = await _context.Transaction.ToListAsync();
            string result = string.Empty;
            trs.ForEach(t => result += JsonConvert.SerializeObject(t));
            return result;
        }

        // GET: api/transactions/5
        [HttpGet("{id}")]
        public async Task<string> Get(int? id)
        {
            //if (id == null)
            //{
            //    return null;
            //}

            var transaction = await _context.Transaction
                .SingleOrDefaultAsync(m => m.Id == id);
            //if (transaction == null)
            //{
            //    return null;
            //}

            return $"value = {id}";
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
