using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarService.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Raise([CallerMemberName]string property = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public bool IsNew = false;
    }
}
