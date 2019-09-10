using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.ApplicationService;

namespace NekoPetShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService petService;

        public PetsController(IPetService petService)
        {
            this.petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return petService.GetPets();
        }

        // GET api/pets/true
        [HttpGet("{type}")]
        public ActionResult<IEnumerable<Pet>> Get(SortType type)
        {
            return petService.SortPetsByPrice(type);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Name is required to create a pet");
            }
            return Ok(petService.CreatePet(pet));
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pet pet)
        {
            if (id < 0)
            {
                return StatusCode(404,"No ID under 0 exists");
            }
            else if (id != pet.Id)
            {
                return BadRequest("Parameter ID and pet ID have to be the same");
            }
            return Ok(petService.UpdatePet(id, pet));
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Pet petToDelete = petService.DeletePet(id);
            if (petToDelete == null)
            {
                return StatusCode(404,$"Did not find pet with ID: {id}");
            }
            return Ok($"Deleted pet with ID: {id}");
        }
    }
}