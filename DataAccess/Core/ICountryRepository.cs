using Data.Entities;
using System.Collections.Generic;

namespace DataAccess.Core
{
    public interface ICountryRepository
    {
        Country GetCountryDetails(string name);
        List<Country> GetCountries();
    }
}
