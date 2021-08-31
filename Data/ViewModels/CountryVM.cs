using System;
using System.Collections.Generic;

namespace Data.ViewModels
{
    public class CountryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PricePerDay { get; set; }
        public List<DayOfWeek> OffDays { get; set; }
        public string Curreny { get; set; }
    }
}
