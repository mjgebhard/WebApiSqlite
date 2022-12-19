using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSqlite.Data;
using WebApiSqlite.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionItemController : ControllerBase
    {
        private readonly WebApiSqliteContext _context;
        public ActionItemController(WebApiSqliteContext context)
        {
            _context = context;
        }
        // GET: api/<ActionItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ActionItemController>/5
        [HttpGet("{id}")]
        public string GetActionItem(int id)
        {
            return "value";
        }

        // POST api/<ActionItemController>
        [HttpPost("{id}")]
        public async Task<ActionResult<ActionItemPoco>> Post(int id, [FromBody] ActionItemPoco poco)
        {
            Developer? developer = await _context.Developers
                .Include(a => a.ActionItems)
                .FirstOrDefaultAsync(d => d.DeveloperId == id);

            if (developer == null)
            {
                return NotFound();
            }

            ActionItem ac = new ActionItem()
            {
                ActionItemId = 0,
                DeveloperId = poco.DeveloperId,
                CloseDate = poco.CloseDate,
                Description = poco.Description,
                OpenDate = poco.OpenDate,
                PlanDate = poco.PlanDate,
                State = poco.State,
                Tilte = poco.Tilte
            };

            developer.ActionItems.Add(ac);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActionItem), new { id = ac.ActionItemId }, poco);
        }

        // PUT api/<ActionItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActionItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
