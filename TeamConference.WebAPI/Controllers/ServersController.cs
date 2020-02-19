using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamConference.WebAPI.Models;

namespace TeamConference.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly TeamConferenceContext dbContext;

        public ServersController(TeamConferenceContext context)
        {
            dbContext = context;
        }

        // GET: api/Servers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Server>>> GetServers()
        {
            return await dbContext.Servers.ToListAsync();
        }

        // GET: api/Servers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Server>> GetServer(Guid id)
        {
            var server = await dbContext.Servers.FindAsync(id);

            if (server == null)
            {
                return NotFound();
            }

            return server;
        }

        // PUT: api/Servers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServer(Guid id, Server server)
        {
            if (id != server.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(server).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Servers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Server>> PostServer(Server server)
        {
            dbContext.Servers.Add(server);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetServer", new { id = server.Id }, server);
        }

        // DELETE: api/Servers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Server>> DeleteServer(Guid id)
        {
            var server = await dbContext.Servers.FindAsync(id);
            if (server == null)
            {
                return NotFound();
            }

            dbContext.Servers.Remove(server);
            await dbContext.SaveChangesAsync();

            return server;
        }

        private bool ServerExists(Guid id)
        {
            return dbContext.Servers.Any(e => e.Id == id);
        }
    }
}
