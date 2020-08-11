using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MusicPlayer
{
    internal class PlayListManagerService : IHostedService
    {
        private readonly IPlayListManager _manager;
        private readonly ILogger<PlayListManagerService> _logger;

        public PlayListManagerService(IPlayListManager manager, ILogger<PlayListManagerService> logger)
        {
            _manager = manager;
            _logger = logger;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting up playlist service...");
            _manager.Play().ConfigureAwait(false);
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _manager.Dispose();

            return Task.CompletedTask;

        }
    }
}