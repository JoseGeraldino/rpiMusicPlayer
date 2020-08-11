using System;
using System.Threading.Tasks;

namespace MusicPlayer
{
    internal interface IPlayListManager : IDisposable
    {
        Task Play();

    }
}