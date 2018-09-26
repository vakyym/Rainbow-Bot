using Discord;
using Discord.WebSocket;
using Role.Handlers;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace Role.Core
{
    public class Core
    {
        public static void Main(string[] args) => new Core().LoginAsync().GetAwaiter().GetResult();

        public async Task LoginAsync()
        {
            var services = new ServiceCollection()
            .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {
                MessageCacheSize = 50,
                AlwaysDownloadUsers = true,
                LogLevel = LogSeverity.Verbose
            }))
            .AddSingleton<CoreHandler>();
            var provider = services.BuildServiceProvider();
            await provider.GetRequiredService<CoreHandler>().InitializeAsync();
            await Task.Delay(-1);
        }
    }
}