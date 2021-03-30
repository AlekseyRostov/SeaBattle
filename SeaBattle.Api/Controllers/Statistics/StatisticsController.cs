using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeaBattle.Application.Interfaces;

namespace SeaBattle.Api.Controllers.Statistics
{
    [ApiController]
    public class StatisticsController: ControllerBase
    {
        private readonly IBattleStatisticService _battleStatisticService;

        public StatisticsController(IBattleStatisticService battleStatisticService)
        {
            _battleStatisticService = battleStatisticService;
        }

        [HttpGet]
        [Route("state")]
        public async Task<StatisticsResponse> GetStatistics()
        {
            return (await _battleStatisticService.GetStatistics()).ToRest();
        } 
    }
}