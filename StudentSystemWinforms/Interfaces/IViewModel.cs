using System.ComponentModel;

namespace StudentSystemWinForms.Interfaces
{
    public interface IViewModel
    {
        void OnPropertyChanged(PropertyChangedEventArgs e);
    }
}
