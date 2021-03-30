using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeaBattle.Application.Interfaces;

namespace SeaBattle.Api.Controllers.Battle
{
    [ApiController]
    public class BattleController:ControllerBase
    {
        private readonly IBattleService _battleService;

        public BattleController(IBattleService battleService)
        {
            _battleService = battleService;
        }

        [HttpPost]
        [Route("create-matrix")]
        public async Task<IActionResult> Create([FromBody] CreateBattleCommand command)
        {
            await _battleService.CreateBattle(command.Range);
            return Ok();
        }
        
        [HttpPost]
        [Route("clear")]
        public async Task<IActionResult> Clear()
        {
            await _battleService.ClearBattle();
            return Ok();
        }
    }
}