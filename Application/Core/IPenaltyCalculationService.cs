using System;

namespace Application.Core
{
    public interface IPenaltyCalculationService
    {
        string Calculate(DateTime start, DateTime end, string name);
    }
}
