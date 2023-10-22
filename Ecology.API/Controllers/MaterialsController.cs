﻿using Ecology.API.Data;
using Ecology.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecology.API.Controllers
{

    [ApiController]
    [Route("api/materials")]
    public class MaterialsController:ControllerBase
    {

        private readonly DataContext _context;


        public MaterialsController (DataContext context) { 

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await  _context.Materials.ToListAsync());
        }


        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)

        {  //200 Ok 

            var material = await _context.Materials.FirstOrDefaultAsync(x => x.Id == id);

            if (material == null)

            {
                return NotFound();

            }
            return Ok(material);
        }


        [HttpPost]

        public async Task<ActionResult> Post(Material material)

        {

            _context.Add(material);

            await _context.SaveChangesAsync();

            return Ok(material);

        }
    }
}
