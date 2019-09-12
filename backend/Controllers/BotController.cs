using CodeBattle.PointWar.Server.Models;
using CodeBattle.PointWar.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodeBattle.PointWar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotsController : ControllerBase
    {
        private readonly BotService _botService;

        public BotsController(BotService botService)
        {
            _botService = botService;
        }

        [HttpGet]
        public ActionResult<List<Bot>> Get() =>
            _botService.Get();

        [HttpGet("{email:length(24)}", Name = "GetBot")]
        public ActionResult<Bot> Get(string email)
        {
            var bot = _botService.Get_from_email(email);

            if (bot == null)
            {
                return NotFound();
            }

            return bot;
        }

        [HttpPost]
        public ActionResult<Bot> Create(Bot bot)
        {
            _botService.Create(bot);

            return CreatedAtRoute("GetBot", new { email = bot.Email_Player.ToString() }, bot);
        }

        [HttpPut("{email:length(24)}")]
        public IActionResult Update(string email, Bot botIn)
        {
            var bot = _botService.Get_from_email(email);

            if (bot == null)
            {
                return NotFound();
            }

            _botService.Update(email, botIn);

            return NoContent();
        }

        [HttpDelete("{email:length(24)}")]
        public IActionResult Delete(string email)
        {
            var bot = _botService.Get_from_email(email);

            if (bot == null)
            {
                return NotFound();
            }

            _botService.Remove(bot.Email_Player);

            return NoContent();
        }
    }
}