using Application.Core;
using Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Penalty_Calculation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Countries : ControllerBase
    {
        private ICountryService _countryService;
        public Countries(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public ActionResult<List<CountryVM>> Get()
        {
            var countries = _countryService.Get();
            return Ok(countries);
        }
    }
}
