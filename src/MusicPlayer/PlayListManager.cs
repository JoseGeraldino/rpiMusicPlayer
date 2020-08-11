using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer
{
    internal class PlayListManager : IPlayListManager
    {
        private static int songsplayed = 0;
        private static readonly string[] validTypes = "mp3 ogg m4u wma wav".Split(' ');
        private static readonly string directory = "/mnt/andoria/media/music";
        private Process _player;
        public PlayListManager()
        {

        }
        private void BackgroundPlayer(List<string> files = null, string file = null)
        {
            if (songsplayed % 10 == 0)
            {
                files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories)
                    .Where(file => file.Length > 4)
                    .Select(file => new { File = file, Ext = file.Substring(file.Length - 3, 3) })
                    .Where(file => validTypes.Contains(file.Ext))
                    .Select(file => file.File)
                    .ToList();
            }


            if (!(file is null))
            {
                try
                {
                    Console.WriteLine(file);
                    _player = new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "omxplayer",
                            Arguments = $"-o alsa \"{file}\" --vol 750 & ",
                            RedirectStandardOutput = false,
                            CreateNoWindow = true,
                            RedirectStandardError = true,
                            RedirectStandardInput = false,
                            UseShellExecute = false

                        }
                    };
                    Console.WriteLine($"Songs Played:{++songsplayed}");
                    _player.Start();
                    _player.WaitForExit();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            BackgroundPlayer(files, files.OrderBy(file => Guid.NewGuid()).First());
        }

        public async Task Play()
        {
            await Task.Run(() =>
              {
                  BackgroundPlayer(null, null);
              });

        }

        public void Dispose()
        {
            if (_player != null)
            {

                _player.Dispose();
            }
        }
    }
}
