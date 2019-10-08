using Engine.EventArgs;
using System;

namespace Engine.ViewModels
{
    public class BaseViewModel
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        protected void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}
