using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
namespace Role.Handlers
{
    public class CoreHandler
    {
        public static DiscordSocketClient Client;
        static Timer Timer;
        public CoreHandler(DiscordSocketClient client)
        {
            Client = client;
        }
        public async Task InitializeAsync()
        {
            // bot token goes in (TokenType.Bot, "")
            await Client.LoginAsync(TokenType.Bot, "").ConfigureAwait(false);
            await Client.StartAsync().ConfigureAwait(false);
            StartRoleService();
        }
        internal static void StartRoleService()
        {
            try
            {
                Timer = new Timer(_ =>
                {
                    Task.Run(async () =>
                    {
                        // server id goes in GetGuild() 
                        var Guild = Client.GetGuild() as SocketGuild;
                        var Role = Guild.Roles.Where(x => x.Name == "?").FirstOrDefault() as SocketRole;
                        await Role.ModifyAsync(x => x.Color = new Color(240, 62, 62));
                        Thread.Sleep(15000);
                        Console.WriteLine("Succesfully changed color");
                        await Role.ModifyAsync(x => x.Color = new Color(238, 134, 64));
                        Thread.Sleep(15000);
                        Console.WriteLine("Succesfully changed color");
                        await Role.ModifyAsync(x => x.Color = new Color(236, 222, 113));
                        Thread.Sleep(15000);
                        Console.WriteLine("Succesfully changed color");
                        await Role.ModifyAsync(x => x.Color = new Color(97, 223, 97));
                        Thread.Sleep(15000);
                        Console.WriteLine("Succesfully changed color");
                        await Role.ModifyAsync(x => x.Color = new Color(80, 161, 236));
                        Thread.Sleep(15000);
                        Console.WriteLine("Succesfully changed color");
                        await Role.ModifyAsync(x => x.Color = new Color(164, 110, 199));
                        Thread.Sleep(15000);
                        Console.WriteLine("Succesfully changed color");
                        Console.WriteLine("### RESTARTING SERVICE ###");
                    });
                }, null, TimeSpan.FromMilliseconds(105000), TimeSpan.FromMilliseconds(105000));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
