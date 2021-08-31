using Data.ViewModels;
using System.Collections.Generic;

namespace Application.Core
{
    public interface ICountryService
    {
        List<CountryVM> Get();
        CountryVM Get(string name);
    }
}
