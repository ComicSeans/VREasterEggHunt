using System;

namespace SeanStandardScript
{
    public interface IPausable
    {
        bool Paused { get; }
        void Pause();
        void UnPause();
    }
}
