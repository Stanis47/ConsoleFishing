using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Engine.NPC
{
    public abstract class BaseNotificationClass : INotifyPropertyChanged
    {
        protected virtual void RaisePropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    } 
}
