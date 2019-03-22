using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BabyShop
{
    public class BindableBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T val,
          [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void RaisePropertyChanged(BindableBase ViewModel, string property)
        {
            PropertyChanged(ViewModel, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
