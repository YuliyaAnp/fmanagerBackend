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
        private readonly TransactionContext context;

        public TransactionsController(TransactionContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAll()
        {            
            return await context.Transaction.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await context.Transaction.SingleOrDefaultAsync(t => t.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return new ObjectResult(transaction);
        }

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
