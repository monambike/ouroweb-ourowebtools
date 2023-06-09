using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OuroWebTools.Desktop.ViewModels
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string name;
        public string Name { get => name; set => SetField(ref name, value); }

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;

            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
