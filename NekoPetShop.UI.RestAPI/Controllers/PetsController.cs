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

        // GET api/pets/getcheapest
        [HttpGet]
        [Route("getcheapest")]
        public ActionResult<IEnumerable<Pet>> GetCheapest()
        {
            return petService.GetCheapestPets();
        }

        // GET api/pets/animal type
        [HttpGet("{type}")]
        [Route("getbytype")]
        public ActionResult<IEnumerable<Pet>> GetByType(AnimalType type)
        {
            return petService.SearchPetsByType(type);
        }

        // GET api/pets/sort type
        [HttpGet("{type}")]
        [Route("getbyprice")]
        public ActionResult<IEnumerable<Pet>> GetByPrice(SortType type)
        {
            return petService.SortPetsByPrice(type);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(petService.CreatePet(pet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pet pet)
        {
            try
            {
                if (id != pet.Id)
                {
                    return BadRequest("Parameter ID and pet ID have to be the same");
                }
                return Ok(petService.UpdatePet(id, pet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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