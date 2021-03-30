using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeaBattle.Application.Interfaces;

namespace SeaBattle.Api.Controllers.Ship
{
    [ApiController]
    public class ShipController:ControllerBase
    {
        private readonly IShipService _shipService;

        public ShipController(IShipService shipService)
        {
            _shipService = shipService;
        }

        [HttpPost]
        [Route("ship")]
        public async Task<IActionResult> CreateShips([FromBody] CreateShipsCommand command)
        {
            await _shipService.CreateShips(command.Coordinates);
            return Ok();
        }

        [HttpPost]
        [Route("shot")]
        public async Task<ShotInformationResponse> Shot([FromBody] ShotCommand command)
        {
            var result = await _shipService.Shot(command.Coordinates);
            return result.ToRest();
        }

    }
}