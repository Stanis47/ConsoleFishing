using Engine.EventArgs;
using System;

namespace Engine.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        public void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}
