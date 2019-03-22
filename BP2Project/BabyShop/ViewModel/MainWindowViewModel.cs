using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyShop.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private RegisterViewModel loginViewModel = new RegisterViewModel();

        public MainWindowViewModel()
        {
            CurrentViewModel = loginViewModel;
            ViewModelHelper.Instance.MainViewModel = this;
        }

        public BindableBase CurrentViewModel
        {
            get { return ViewModelHelper.Instance.CurrentViewModel; }
            set
            {
                ViewModelHelper.Instance.CurrentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }
    }
}
