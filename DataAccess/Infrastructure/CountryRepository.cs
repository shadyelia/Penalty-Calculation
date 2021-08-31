using Data.Entities;
using DataAccess.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess.Infrastructure
{
    public class CountryRepository : ICountryRepository
    {
        public List<Country> GetCountries()
        {
            List<Country> countries;
            using (StreamReader r = new("./Files/Countries.json"))
            {
                string json = r.ReadToEnd();
                countries = JsonConvert.DeserializeObject<List<Country>>(json);
            }
            return countries;
        }

        public Country GetCountryDetails(string name)
        {
            List<Country> countries;
            using (StreamReader r = new("./Files/Countries.json"))
            {
                string json = r.ReadToEnd();
                countries = JsonConvert.DeserializeObject<List<Country>>(json);
            }
            return countries.FirstOrDefault(c => c.Name == name);
        }
    }
}
