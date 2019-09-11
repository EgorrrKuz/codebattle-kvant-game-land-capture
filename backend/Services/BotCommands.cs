using System;
using System.Threading.Tasks;
using CodeBattle.PointWar.Server.Models;
using CodeBattle.PointWar.Server.Controllers;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.IO;

namespace CodeBattle.PointWar.Server.Services
{
    public class BotCommands : Hub
    {
        PlayerService player = new PlayerController();

        /// <summary>
        /// Go to Up
        /// </summary>
        public async Task Up(int x, int y, string email, string pass, string api)
        {
            // New object
            Bot bot = new Bot(y, x, email, pass, api);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                // Send to clint
                await Clients.Caller.SendAsync("Up", bot.X_Bot, bot.Y_Bot--, bot.Email_Player); 
                // Send to Front - end
                await Clients.All.SendAsync("UpFront", bot.X_Bot, bot.Y_Bot--, bot.Email_Player);
                
                Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - moved up ");
            }
            else
            {
                // Send to clint
                await Clients.Caller.SendAsync("Up", bot.X_Bot, bot.Y_Bot, bot.Email_Player);
                // Send to Front - end
                await Clients.All.SendAsync("UpFront", bot.X_Bot, bot.Y_Bot, bot.Email_Player); 
                
                Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - could not move");
            }
        }

        /// <summary>
        /// Go to Down
        /// </summary>
        public async Task Down(int x, int y, string email, string pass, string api)
        {
            // New object
            Bot bot = new Bot(y, x, email, pass, api);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                await Clients.Caller.SendAsync("Down", bot.X_Bot, bot.Y_Bot++, bot.Email_Player); // Send to clint
                await Clients.All.SendAsync("DownFront", bot.X_Bot, bot.Y_Bot++, bot.Email_Player); // Send to Front - end

                Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - moved down ");
            }
            else
            {
                await Clients.Caller.SendAsync("Down", bot.X_Bot, bot.Y_Bot, bot.Email_Player); // Send to clint
                await Clients.All.SendAsync("DownFront", bot.X_Bot, bot.Y_Bot, bot.Email_Player); // Send to Front - end

                Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - could not move");
            }
        }

        /// <summary>
        /// Go to left
        /// </summary>
        public async Task Left(int x, int y, string email, string pass, string api)
        {
            // New object
            Bot bot = new Bot(y, x, email, pass, api);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                await Clients.Caller.SendAsync("Left", bot.X_Bot--, bot.Y_Bot, bot.Email_Player); // Send to clint
                await Clients.All.SendAsync("LeftFront", bot.X_Bot--, bot.Y_Bot, bot.Email_Player); // Send to Front - end

                Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - moved left ");
            }
            else
            {
                await Clients.Caller.SendAsync("Left", bot.X_Bot, bot.Y_Bot, bot.Email_Player); // Send to clint
                await Clients.All.SendAsync("LeftFront", bot.X_Bot, bot.Y_Bot, bot.Email_Player); // Send to Front - end

                Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - could not move");
            }
        }

        /// <summary>
        /// Go to Right
        /// </summary>
        public async Task Right(int x, int y, string email, string pass, string api)
        {
            // New object
            Bot bot = new Bot(y, x, email, pass, api);
            Block block = new Block();

            // Check blocks, after send "bot"
            if (block.IsBlock(bot.Y_Bot--, bot.X_Bot) == false)
            {
                await Clients.Caller.SendAsync("Right", bot.X_Bot++, bot.Y_Bot, bot.Email_Player); // Send to clint
                await Clients.All.SendAsync("RightFront", bot.X_Bot++, bot.Y_Bot, bot.Email_Player); // Send to Front - end

                Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - moved lefrightt ");
            }
            else
            {
                await Clients.Caller.SendAsync("Right", bot.X_Bot, bot.Y_Bot, bot.Email_Player); // Send to clint
                await Clients.All.SendAsync("RightFront", bot.X_Bot, bot.Y_Bot, bot.Email_Player); // Send to Front - end

                Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - could not move");
            }
        }

        /// <summary>
        /// Add point
        /// </summary>
        public async Task AddPoint(int x, int y, string id)
        {
            // New object
            Point point = new Point(y, x, id);
            point.Active = true;

            // Check point, after send "point"
            if (point.IsPoint(point.Y_Point, point.X_Point) == false)
            {
                // Check file
                string file = "points.json";

                if (!File.Exists(file))
                    File.Create(file);

                // Send to clint
                await Clients.Caller.SendAsync("AddPoint", point.X_Point, point.Y_Point, point.PlayerID);

                File.WriteAllText(file, JsonConvert.SerializeObject(point));

                // Send to Front-end
                await Clients.Caller.SendAsync("AddPointFront", point.X_Point, point.Y_Point, point.PlayerID);

                Console.WriteLine($"Bot ({point.PlayerID}) - add point [{point.X_Point}; {point.Y_Point}]");
            }
        }
    }
}