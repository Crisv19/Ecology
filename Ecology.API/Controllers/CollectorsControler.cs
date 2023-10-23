using Ecology.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecology.Shared.Entities;

namespace Ecology.API.Controllers
{
    [ApiController]
    [Route("/api/Collectors")]
    public class CollectorsController : ControllerBase
    {
        private readonly DataContext _context;

        public CollectorsController(DataContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Collectors.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var collector = await _context.Collectors.FirstOrDefaultAsync(x => x.Id == id);

            if (collector == null)
            {


                return NotFound();
            }

            return Ok(collector);


        }


        [HttpPost]
        public async Task<ActionResult> Post(Collector Collector)
        {
            _context.Add(Collector);
            await _context.SaveChangesAsync();
            return Ok(Collector);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Collector collector)
        {
            _context.Update(collector);
            await _context.SaveChangesAsync();
            return Ok(collector);
        }




        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Collectors
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}