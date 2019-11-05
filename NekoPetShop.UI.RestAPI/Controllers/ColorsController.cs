using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;


        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        // GET api/colors -- READ ALL
        [HttpGet]
        public ActionResult<IEnumerable<Color>> Get([FromQuery] Filter filter)
        {
            try
            {
                return _colorService.ReadAll(filter);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/colors/5 -- READ BY ID
        [HttpGet("{id}")]
        public ActionResult<Color> Get(int id)
        {
            return _colorService.ReadById(id);
        }

        // POST api/colors -- CREATE
        [HttpPost]
        public ActionResult Post([FromBody] Color color)
        {
            try
            {
                return Ok(_colorService.Create(color));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/colors/5 -- UPDATE
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Color color)
        {
            try
            {
                if (id != color.Id)
                {
                    return BadRequest($"Parameter ID({id}) and color ID({color.Id}) have to be the same");
                }
                return Ok(_colorService.Update(color));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/colors/5 -- DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _colorService.Delete(id);
                return Ok($"Deleted color with Id: {id}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}