using Ecology.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecology.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;



namespace Ecology.API.Controllers

{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]

    [Route("/api/storages")]

    public class StoragesController : ControllerBase

    {

        private readonly DataContext _context;



        public StoragesController(DataContext context)

        {

            _context = context;

        }



        [HttpGet]

        public async Task<ActionResult> Get()

        {

            return Ok(await _context.Storages.ToListAsync());

        }


        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)

        {  //200 Ok 

            var storage = await _context.Storages.FirstOrDefaultAsync(x => x.Id == id);

            if (storage == null)

            {
                return NotFound();

            }
            return Ok(storage);
        }



        [HttpPost]

        public async Task<ActionResult> Post(Storage storage)

        {

            _context.Add(storage);

            await _context.SaveChangesAsync();

            return Ok(storage);

        }

        [HttpPut]
        public async Task<ActionResult> Put(Storage storage)
        {
            _context.Update(storage);
            await _context.SaveChangesAsync();
            return Ok(storage);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Storages
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