using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.Core.Entity.Filtering;

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
		[Authorize]
		[HttpGet]
		public ActionResult<FilteredList<Pet>> Get([FromQuery] Filter filter)
		{
			try
			{
				FilteredList<Pet> filteredPets = _petService.ReadAll(filter);
				List<Object> advancedFilteredPets = new List<object>();
				foreach (Pet pet in filteredPets.List)
				{
					advancedFilteredPets.Add(new { pet.Id, pet.Name, pet.Price, pet.Type, age = DateTime.Today.Year - pet.Birthdate.Year, pet.Birthdate, pet.SoldDate, pet.Owner, pet.PetColors });
				}
				return Ok(new FilteredList<object> { TotalPages = filteredPets.TotalPages, List = advancedFilteredPets }); ;
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// GET api/pets/5 -- READ BY ID
		[Authorize]
		[HttpGet("{id}")]
		public ActionResult<Pet> Get(int id)
		{
			return _petService.ReadById(id);
		}

		// POST api/pets -- CREATE
		[Authorize(Roles = "Administrator")]
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

		// PUT api/pets/5 - UPDATE
		[Authorize(Roles = "Administrator")]
		[HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pet pet)
        {
            try
            {
                if (id != pet.Id)
                {
                    return BadRequest($"Parameter ID({id}) and pet ID({pet.Id}) have to be the same");
                }
                return Ok(_petService.Update(pet));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		// DELETE api/pets/5 -- DELETE
		[Authorize(Roles = "Administrator")]
		[HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _petService.Delete(id);
                return Ok($"Deleted pet with Id: {id}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}