using BabyShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BabyShop.DBAccess;

namespace BabyShop.ViewModel
{
    public class RegisterViewModel : BindableBase
    {
        public MyICommand RegisterCommand { get; set; }
        public MyICommand LoginCommand { get; set; }

        public static Korisnik currentUser = new Korisnik();
        private string username;
        private string password;
        private string ime;
        private string prezime;
        private string usernameL;
        private string passwordL;
        private string errorLogin;
        private string errorRegister;

        public RegisterViewModel()
        {
            RegisterCommand = new MyICommand(OnRegister);
            LoginCommand = new MyICommand(OnLogin);
        }

        public static Korisnik CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
            }
        }

        public void OnRegister()
        {
            if(DBAccess.DBAccess.Instance.Korisniks.ToList().Exists(x => x.Username == Username))
            {
                //Error, username vec postoji
                ErrorRegister = "Username vec postoji!";
            }
            else if(DBAccess.DBAccess.Instance.Korisniks.ToList().Exists(x => x.Password == Password))
            {
                //Error, password vec postoji
                ErrorRegister = "Password vec postoji!";
            }
            else
            {
                if (String.IsNullOrWhiteSpace(Username) || String.IsNullOrWhiteSpace(Password) ||
                    String.IsNullOrWhiteSpace(Ime) || String.IsNullOrWhiteSpace(Prezime))
                {
                    ErrorRegister = "Molimo popunite sva polja!";
                }
                else
                {
                    //Uspesna registracija
                    DBAccess.DBAccess.Instance.Kupacs.Add(new Kupac()
                    {
                        Korisnik = new Korisnik()
                        {
                            Username = Username,
                            Password = Password,
                            Ime = Ime,
                            Prezime = Prezime
                        }
                    });
                    DBAccess.DBAccess.Instance.SaveChanges();

                    CurrentUser = DBAccess.DBAccess.Instance.Korisniks.ToList().Find(x => x.Username == Username);
                    ViewModelHelper.Instance.CurrentViewModel = new CatalogViewModel();
                    RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
                }
            }
        }

        public void OnLogin()
        {
            if (!DBAccess.DBAccess.Instance.Korisniks.ToList().Exists(x => x.Username == UsernameL))
                ErrorLogin = "Pogresno korisnicko ime!";
            else if (!DBAccess.DBAccess.Instance.Korisniks.ToList().Exists(x => x.Password == PasswordL))
                ErrorLogin = "Pogresna lozinka!";
            else
            {
                if (string.IsNullOrWhiteSpace(UsernameL) && string.IsNullOrWhiteSpace(PasswordL))
                    ErrorLogin = "Molimo popunite sva polja!";
                else
                {
                    CurrentUser = DBAccess.DBAccess.Instance.Korisniks.ToList().Find(x => x.Username == UsernameL && x.Password == PasswordL);
                    if (CurrentUser == null)
                        ErrorLogin = "Greska prilikom logovanja!";
                    else
                    {
                        ViewModelHelper.Instance.CurrentViewModel = new CatalogViewModel();
                        RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
                    }
                }
            }
        }

        #region Properties

        public string ErrorLogin
        {
            get { return errorLogin; }
            set
            {
                errorLogin = value;
                OnPropertyChanged("ErrorLogin");
            }
        }

        public string ErrorRegister
        {
            get { return errorRegister; }
            set
            {
                errorRegister = value;
                OnPropertyChanged("ErrorRegister");
            }
        }

        public string UsernameL
        {
            get { return usernameL;}
            set
            {
                usernameL = value;
                OnPropertyChanged("UsernameL");
            }
        }

        public string PasswordL
        {
            get { return passwordL; }
            set
            {
                passwordL = value;
                OnPropertyChanged("PasswordL");
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
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
