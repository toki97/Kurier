using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOfPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(name, new PropertyChangedEventArgs(name));
        }

        protected void Set<T>(ref T property, T value)
        {
            property = value;
            NotifyOfPropertyChanged(nameof(property));
        }
    }
}
