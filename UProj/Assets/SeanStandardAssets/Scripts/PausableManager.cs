using System;

namespace SeanStandardScript
{
    public class PausableManager
    {
        public bool Paused { get; private set; }

        private event Action OnPause;
        private event Action OnUnpause;

        public void AddIPausable(IPausable iPausable)
        {
            OnPause += iPausable.Pause;
            OnUnpause += iPausable.UnPause;
        }

        public void RemoveIPausable(IPausable iPausable)
        {
            OnPause -= iPausable.Pause;
            OnUnpause -= iPausable.UnPause;
        }

        public void Pause()
        {
            if (Paused) return;
            Paused = true;
            if (OnPause != null) OnPause();
        }

        public void UnPause()
        {
            if (!Paused) return;
            Paused = false;
            if (OnUnpause != null) OnUnpause();
        }

    }
}