using CodeBattle.PointWar.Server.Models;
using CodeBattle.PointWar.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeBattle.PointWar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayersController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public ActionResult<List<Player>> Get() =>
            _playerService.Get();

        [HttpGet("{email:length(24)}", Name = "GetPlayer")]
        public ActionResult<Player> Get(string email)
        {
            var player = _playerService.Get(email);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        [HttpPost]
        public ActionResult<Player> Create(Player player)
        {
            _playerService.Create(player);

            return CreatedAtRoute("GetPlayer", new { id = player.ID.ToString() }, player);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Player playerIn)
        {
            var player = _playerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _playerService.Update(id, playerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var player = _playerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _playerService.Remove(player.ID);

            return NoContent();
        }
    }
}