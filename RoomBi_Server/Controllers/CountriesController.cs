﻿using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;



namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(IServiceOfAll<CountryDTO> countryService) : ControllerBase
    {
        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var country = await countryService.GetAll();
            if (country == null || !country.Any())
            {
                return NotFound();
            }
            return Ok(country);
        }
        // GET: api/Countries/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CountryDTO>> GetCountry(int id)
        //{
        //    var country = await countryService.Get(id);
        //    if (country == null)
        //    {
        //        return NotFound();
        //    }
        //    return country;
        //}

        //// PUT: api/Countries/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCountry(int id, CountryDTO country)
        //{
        //    if (id != country.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await countryService.Update(country);
        //    return NoContent();
        //}

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<CountryDTO>> PostCountry(CountryDTO country)
        {
            await countryService.Create(country);
            //return CreatedAtAction("GetLanguage", new { id = language.Id }, language);
            return NoContent();
        }

        //// DELETE: api/Countries/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCountry(int id)
        //{
        //    await countryService.Delete(id);
        //    return NoContent();
        //}

    }
}
