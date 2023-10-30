using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldApi.Data;
using WorldApi.DTO.Country;
using WorldApi.Models;

namespace WorldApi.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CountryController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public ActionResult<createCountryDto> createCountry([FromBody] createCountryDto countrydto)
        {
            Country country = new Country();
            country.Name = countrydto.Name;
            country.ShortName = countrydto.ShortName;
            country.CountryCode= countrydto.CountryCode;

            applicationDbContext.Countries.Add(country);
            applicationDbContext.SaveChanges();
            return Ok(country);
        }

        [HttpGet]
        public IEnumerable<Country> GetAll()
        {
           return applicationDbContext.Countries;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Country> Get(int id)
        {
            var country = applicationDbContext.Countries.FirstOrDefault(g => g.Id == id);
            return Ok(country);
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Country> UpdateCountry([FromRoute] int id, [FromBody] Country country)
        {
            var country_ = applicationDbContext.Countries.FirstOrDefault(u=> u.Id == id);
            if(country_ != null)
            {
                country_.Name= country.Name;
                country_.ShortName= country.ShortName;
                country_.CountryCode = country.CountryCode;

                applicationDbContext.SaveChanges();
                return country_;
            }
            else
            {
                return NotFound("Country Id Not Found ");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Country> DeleteCountry([FromRoute] int id)
        {
            var country_ = applicationDbContext.Countries.FirstOrDefault(u => u.Id == id);
            if (country_ != null)
            {
               applicationDbContext.Remove(country_);

                applicationDbContext.SaveChanges();
                return country_;
            }
            else
            {
                return NotFound("Country Id Not Found ");
            }
        }

    }
}
