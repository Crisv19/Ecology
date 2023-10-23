using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using Ecology.API.Data;

using Ecology.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Market.API.Controllers

{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]

    [Route("/api/Leaders")]

    public class LeadersController : ControllerBase

    {

        private readonly DataContext _context;



        public LeadersController(DataContext context)

        {

            _context = context;

        }






        [HttpGet]

        public async Task<ActionResult> Get()

        {



            return Ok(await _context.Leaders.ToListAsync());





        }



        // Get por parámetro 

        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)

        {



            //200 Ok 



            var leader = await _context.Leaders.FirstOrDefaultAsync(x => x.Id == id);



            if (leader == null)

            {





                return NotFound();

            }



            return Ok(leader);





        }





        [HttpPost]

        public async Task<ActionResult> Post(Leader leader)

        {

            _context.Add(leader);

            await _context.SaveChangesAsync();

            return Ok(leader);

        }


        [HttpPut]
        public async Task<ActionResult> Put(Leader leader)
        {
            _context.Update(leader);
            await _context.SaveChangesAsync();
            return Ok(leader);
        }




        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Leaders
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