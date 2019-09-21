using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.ApplicationService;

namespace NekoPetShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.ReadAll();
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.ReadById(id);
        }

        // GET api/pets/includeowners?id=5
        [HttpGet]
        [Route("includepets")]
        public ActionResult<Owner> GetOwnerByIdIncludePets([FromQuery]int id)
        {
            return _ownerService.ReadByIdIncludePets(id);
        }

        // POST api/owners
        [HttpPost]
        public ActionResult Post([FromBody] Owner owner)
        {
            try
            {
                return Ok(_ownerService.Create(owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/owners/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Owner owner)
        {
            try
            {
                if (id != owner.Id)
                {
                    return BadRequest("Parameter ID and pet ID have to be the same");
                }
                return Ok(_ownerService.Update(id, owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Owner ownerToDelete = _ownerService.Delete(id);
            if (ownerToDelete == null)
            {
                return StatusCode(404, $"Did not find owner with ID: {id}");
            }
            return Ok($"Deleted owner with ID: {id}");
        }
    }
}