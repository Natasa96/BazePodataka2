using BabyShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyShop.ViewModel
{
    public class ProfileViewModel : BindableBase
    {
        private string password;
        private string ime;
        private string prezime;
        private string errorMsg;

        public MyICommand SaveCommand { get; set; }
        public MyICommand BackCommand { get; set; }

        public ProfileViewModel()
        {
            ViewModelHelper.Instance.CurrentViewModel = this;

            SaveCommand = new MyICommand(OnSave);
            BackCommand = new MyICommand(OnBack);
        }

        public void OnBack()
        {
            ViewModelHelper.Instance.CurrentViewModel = new CatalogViewModel();
            RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
        }

        public void OnSave()
        {
            Korisnik korisnik = DBAccess.DBAccess.Instance.Korisniks.ToList().Find(x => x.Username == Username);

            if (DBAccess.DBAccess.Instance.Korisniks.ToList().Exists(x => x.Password == Password))
                ErrorMsg = "Molimo izaberite drugu lozinku";
            else
            {
                if (String.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Ime) || string.IsNullOrEmpty(Prezime))
                    ErrorMsg = "Popunite sva polja!";
                else
                {
                    korisnik.Ime = Ime;
                    korisnik.Prezime = Prezime;
                    korisnik.Password = Password;
                    ErrorMsg = "Uspesno promenjeni podaci!";
                    DBAccess.DBAccess.Instance.SaveChanges();

                    ViewModelHelper.Instance.CurrentViewModel = new ProfileViewModel();
                    RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
                }
            }

        }

        #region Properties

        public string ErrorMsg
        {
            get { return errorMsg; }
            set
            {
                errorMsg = value;
                OnPropertyChanged("ErrorMsg");
            }
        }

        public string Username
        {
            get { return RegisterViewModel.CurrentUser.Username; }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        #endregion
    }
}
