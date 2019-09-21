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
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets -- READ ALL
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petService.ReadAll(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/pets/getcheapest
        [HttpGet]
        [Route("includeowners")]
        public ActionResult<IEnumerable<Pet>> GetPetsIncludeOwners()
        {
            return _petService.ReadAllIncludeOwners();
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.ReadById(id);
        }

        // GET api/pets/includeowners?id=5
        [HttpGet]
        [Route("includeowner")]
        public ActionResult<Pet> GetPetByIdIncludeOwner([FromQuery]int id)
        {
            return _petService.ReadByIdIncludeOwner(id);
        }

        // GET api/pets/getcheapest
        [HttpGet]
        [Route("getcheapest")]
        public ActionResult<IEnumerable<Pet>> GetCheapest()
        {
            return _petService.ReadCheapest();
        }

        // GET api/pets/animaltype?type=enum
        [HttpGet]
        [Route("animaltype")]
        public ActionResult<IEnumerable<Pet>> GetByType([FromQuery]AnimalType type)
        {
            return _petService.ReadByType(type);
        }

        // GET api/pets/animaltype?type=enum
        [HttpGet]
        [Route("pricetype")]
        public ActionResult<IEnumerable<Pet>> GetByPrice([FromQuery]SortType type)
        {
            return _petService.ReadByPrice(type);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult Post([FromBody] Pet pet)
        {
            try
            {
                return Ok(_petService.Create(pet));
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
                return Ok(_petService.Update(id, pet));
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
            Pet petToDelete = _petService.Delete(id);
            if (petToDelete == null)
            {
                return StatusCode(404,$"Did not find pet with ID: {id}");
            }
            return Ok($"Deleted pet with ID: {id}");
        }
    }
}