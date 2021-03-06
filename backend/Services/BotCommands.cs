using System;
using System.Threading.Tasks;
using CodeBattle.PointWar.Server.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.IO;

namespace CodeBattle.PointWar.Server.Services
{
    public class BotCommands : Hub
    {/*
        static string fileName = "../playersettings.json";

        static IPlayersDatabaseSettings config = JsonConvert.DeserializeObject<IPlayersDatabaseSettings>(File.ReadAllText(fileName));

        public PlayerService player = new PlayerService(config);

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
                if (pass == player.Get_from_email(email).Password)
                {
                    int i = 0;
                    while (true)
                    {
                        if (api == player.Get_from_email(email).Email)
                        {
                            bot.Y_Bot = bot.Y_Bot--;

                            // Send to clint
                            await Clients.Caller.SendAsync(
                                "Up", bot.X_Bot, bot.Y_Bot, bot.Email_Player);
                            // Send to Front - end
                            await Clients.All.SendAsync(
                                "BotCoord", bot.X_Bot, bot.Y_Bot, bot.Email_Player);

                            Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - moved up ");
                        }

                        i++;
                    }
                }
            }
            else
            {
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
                if (pass == player.Get_from_email(email).Password)
                {
                    int i = 0;
                    while (true)
                    {
                        if (api == player.Get_from_email(email).Email)
                        {
                            bot.Y_Bot = bot.Y_Bot++;

                            // Send to clint
                            await Clients.Caller.SendAsync(
                                "Down", bot.X_Bot, bot.Y_Bot, bot.Email_Player);
                            // Send to Front - end
                            await Clients.All.SendAsync(
                                "BotCoord", bot.X_Bot, bot.Y_Bot, bot.Email_Player);

                            Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - moved down ");
                        }

                        i++;
                    }
                }
            }
            else
            {
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
                if (pass == player.Get_from_email(email).Password)
                {
                    int i = 0;
                    while (true)
                    {
                        if (api == player.Get_from_email(email).Email)
                        {
                            bot.X_Bot = bot.X_Bot--;

                            // Send to clint
                            await Clients.Caller.SendAsync(
                                "Left", bot.X_Bot, bot.Y_Bot, bot.Email_Player);
                            // Send to Front - end
                            await Clients.All.SendAsync(
                                "BotCoord", bot.X_Bot, bot.Y_Bot, bot.Email_Player);

                            Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - moved left ");
                        }

                        i++;
                    }
                }
            }
            else
            {
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
                if (pass == player.Get_from_email(email).Password)
                {
                    int i = 0;
                    while (true)
                    {
                        if (api == player.Get_from_email(email).Email)
                        {
                            bot.X_Bot = bot.X_Bot++;

                            // Send to clint
                            await Clients.Caller.SendAsync(
                                "Right", bot.X_Bot, bot.Y_Bot, bot.Email_Player);
                            // Send to Front - end
                            await Clients.All.SendAsync(
                                "BotCoord", bot.X_Bot, bot.Y_Bot, bot.Email_Player);

                            Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - moved right ");
                        }

                        i++;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Bot ({bot.API_Key} + {bot.Email_Player}) - could not move");
            }
        }

        /// <summary>
        /// Add point
        /// </summary>
        public async Task AddPoint(int x, int y, string email, string pass, string api)
        {
            // New object
            Point point = new Point(y, x, email, pass, api);
            point.Active = true;

            // Check point, after send "point"
            if (point.IsPoint(point.Y_Point, point.X_Point) == false)
            {
                if (pass == player.Get_from_email(email).Password)
                {
                    int i = 0;
                    while (true)
                    {
                        if (api == player.Em(email).Email)
                        {
                            // Check file
                            string file = "points.json";

                            if (!File.Exists(file))
                                File.Create(file);

                            // Send to clint
                            await Clients.Caller.SendAsync(
                                "AddPoint", point.X_Point, point.Y_Point, point.Player_Email);

                            File.WriteAllText(
                                file, JsonConvert.SerializeObject(point));

                            // Send to Front-end
                            await Clients.Caller.SendAsync(
                                "AddPointFront", point.X_Point, point.Y_Point, point.Player_Email);

                            Console.WriteLine($"Bot ({point.Player_Email}) - add point [{point.X_Point}; {point.Y_Point}]");
                        }

                        i++;
                    }
                }
            }
        }*/
    }
}