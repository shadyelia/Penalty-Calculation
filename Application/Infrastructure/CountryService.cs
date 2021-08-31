using Application.Core;
using Data.Entities;
using Data.ViewModels;
using DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure
{
    public class CountryService : ICountryService
    {
        private ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public List<CountryVM> Get()
        {
            List<Country> countries = _countryRepository.GetCountries();
            List<CountryVM> countryVMs = new List<CountryVM>();
            foreach(var country in countries)
            {
                countryVMs.Add(AutoMapperAlternative(country));
            }
            return countryVMs;
        }

        public CountryVM Get(string name)
        {
            Country country = _countryRepository.GetCountryDetails(name);
            return AutoMapperAlternative(country);
        }

        private CountryVM AutoMapperAlternative(Country country)
        {
            CountryVM countryVM = new CountryVM()
            {
                Id = country.Id,
                Curreny = country.Curreny,
                Name = country.Name,
                OffDays = country.OffDays,
                PricePerDay = country.PricePerDay
            };
            return countryVM;
        }
    }
}
