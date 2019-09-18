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
        private readonly IOwnerService ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return ownerService.GetOwners();
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return ownerService.GetOwnerById(id);
        }

        // POST api/owners
        [HttpPost]
        public ActionResult Post([FromBody] Owner owner)
        {
            try
            {
                return Ok(ownerService.CreateOwner(owner));
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
                return Ok(ownerService.UpdateOwner(id, owner));
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
            Owner ownerToDelete = ownerService.DeleteOwner(id);
            if (ownerToDelete == null)
            {
                return StatusCode(404, $"Did not find owner with ID: {id}");
            }
            return Ok($"Deleted owner with ID: {id}");
        }
    }
}