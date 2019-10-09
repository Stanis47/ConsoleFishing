using Engine.EventArgs;
using System;

namespace Engine.ViewModels
{
    public interface IViewModel
    {
        event EventHandler<GameMessageEventArgs> OnMessageRaised;

        void RaiseMessage(string message);
    }
}
