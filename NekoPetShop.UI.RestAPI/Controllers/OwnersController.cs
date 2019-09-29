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

        // GET api/owners -- READ ALL
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                List<Owner> filteredOwners = _ownerService.ReadAll(filter);
                List<Object> specificOwners = new List<object>();
                foreach (Owner owner in filteredOwners)
                {
                    specificOwners.Add(new { owner.Id, owner.FirstName, owner.LastName, petName = owner.Pets[0].Name ?? "No owner" });
                }
    
                return Ok(specificOwners);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/owners/5 -- READ BY ID
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.ReadById(id);
        }

        // POST api/owners -- CREATE
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

        // PUT api/owners/5 -- UPDATE
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Owner owner)
        {
            try
            {
                if (id != owner.Id)
                {
                    return BadRequest("Parameter ID and owner ID have to be the same");
                }
                return Ok(_ownerService.Update(owner));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/owners/5 -- DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _ownerService.Delete(id);
                return Ok($"Deleted owner with Id: {id}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}