using ReactiveUI;
using System.ComponentModel;

namespace UI.ViewModels
{
    public class ViewModelBase : ReactiveObject,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
