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

    [Route("/api/typMaterials")]

    public class TypMaterialsController : ControllerBase

    {

        private readonly DataContext _context;



        public TypMaterialsController(DataContext context)

        {

            _context = context;

        }



        [HttpGet]

        public async Task<ActionResult> Get()

        {

            return Ok(await _context.TypMaterials.ToListAsync());

        }


        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)

        {  //200 Ok 

            var typMaterial = await _context.TypMaterials.FirstOrDefaultAsync(x => x.Id == id);

            if (typMaterial == null)

            {
                return NotFound();

            }
            return Ok(typMaterial);
        }



        [HttpPost]

        public async Task<ActionResult> Post(TypMaterial typMaterial)

        {

            _context.Add(typMaterial);

            await _context.SaveChangesAsync();

            return Ok(typMaterial);

        }



        [HttpPut]
        public async Task<ActionResult> Put(TypMaterial typMaterial)
        {
            _context.Update(typMaterial);
            await _context.SaveChangesAsync();
            return Ok(typMaterial);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.TypMaterials
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