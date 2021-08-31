using Application.Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Penalty_Calculation.Controllers
{
    [Route("api/Penalty")]
    [ApiController]
    public class PenaltyCalculation : ControllerBase
    {
        private IPenaltyCalculationService _penaltyCalculationService;

        public PenaltyCalculation(IPenaltyCalculationService penaltyCalculationService)
        {
            _penaltyCalculationService = penaltyCalculationService;
        }

        [HttpGet]
        public ActionResult<string> Get(DateTime start, DateTime end, string name)
        {
            var result = _penaltyCalculationService.Calculate(start, end, name);
            return Ok(result);
        }
    }
}
