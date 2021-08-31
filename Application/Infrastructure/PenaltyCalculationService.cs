using Application.Core;
using Data.Entities;
using DataAccess.Core;
using System;
using System.Collections.Generic;

namespace Application.Infrastructure
{
    public class PenaltyCalculationService : IPenaltyCalculationService
    {
        private ICountryRepository _countryRepository;

        public PenaltyCalculationService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public string Calculate(DateTime start, DateTime end, string name)
        {
            var totalDay = (end - start).TotalDays;
            if (totalDay < 1)
                return "There is no penalty on you";

            Country country = _countryRepository.GetCountryDetails(name);
            if (country == null)
                return "Country name is wrong";
            
            int numberOfOffDays = CalculateNumberOfOffDays(start, end, country.OffDays);
            float price = (float)(totalDay - numberOfOffDays) * country.PricePerDay;

            return $"You have {price} {country.Curreny} to pay";
        }

        private static int CalculateNumberOfOffDays(DateTime start, DateTime end, List<DayOfWeek> offDays)
        {
            int result = 0;

            foreach (var day in offDays)
            {
                var form = start;
                var to = end;
                while (form < to)
                {
                    if (form.DayOfWeek == day)
                    {
                        result++;
                        form = form.AddDays(7);
                    }
                    else
                    {
                        form = form.AddDays(1);
                    }
                }
            }

            return result;
        }
    }
}
