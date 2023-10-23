using Ecology.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Ecology.Shared.Entities;

namespace Ecology.API.Controllers
{
    [ApiController]
    [Route("/api/Recyclers")]
    public class RecyclersController : ControllerBase
    {
        private readonly DataContext _context;

        public RecyclersController(DataContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Recyclers.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var recycler = await _context.Recyclers.FirstOrDefaultAsync(x => x.Id == id);

            if (recycler == null)
            {


                return NotFound();
            }

            return Ok(recycler);


        }


        [HttpPost]
        public async Task<ActionResult> Post(Recycler Recycler)
        {
            _context.Add(Recycler);
            await _context.SaveChangesAsync();
            return Ok(Recycler);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Recycler recycler)
        {
            _context.Update(recycler);
            await _context.SaveChangesAsync();
            return Ok(recycler);
        }




        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Recyclers
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