using BabyShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyShop.ViewModel
{
    public class ShoppingCartViewModel : BindableBase
    {
        private string ime;
        private string prezime;
        private string username;
        private string errorMsg;
        private string payMsg;
        private string racun;
        private string sum;
        private List<Artikal> artikals = new List<Artikal>();
        private Artikal selected;

        public MyICommand RemoveCommand { get; set; }
        public MyICommand BackCommand { get; set; }
        public MyICommand PayCommand { get; set; }
        public MyICommand ProfileCommand { get; set; }

        public ShoppingCartViewModel()
        {
            ViewModelHelper.Instance.CurrentViewModel = this;

            RemoveCommand = new MyICommand(OnRemove);
            BackCommand = new MyICommand(OnBack);
            PayCommand = new MyICommand(OnPay);
            ProfileCommand = new MyICommand(OnProfile);

            Ime = RegisterViewModel.CurrentUser.Ime;
            Prezime = RegisterViewModel.CurrentUser.Prezime;
            Username = RegisterViewModel.CurrentUser.Username;

            foreach (var x in DBAccess.DBAccess.Instance.Artikals)
                if (x.Kupacs.ToList().Exists(y => y.Username == Username))
                    artikals.Add(x);
            try
            {
                int temp = DBAccess.DBAccess.Instance.Database.SqlQuery<int>(string.Format("select [dbo].[SumFunction]('{0}')", Username)).FirstOrDefault();
                Sum = "Ukupna suma: " + temp + " RSD";
            }
            catch
            {
                Sum = "Ukupna suma: 0 RSD";
            }
        }

        public void OnProfile()
        {
            ViewModelHelper.Instance.CurrentViewModel = new ProfileViewModel();
            RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
        }

        public void OnPay()
        {
            Kupac kupac = DBAccess.DBAccess.Instance.Kupacs.ToList().Find(x => x.Username == RegisterViewModel.CurrentUser.Username);

            double sum = 0;
            foreach(var item in Artikals2)
            {
                sum += (double)item.Cena;
            }
            if(kupac.Racun > sum)
            {
                kupac.Racun -= sum;

                for(int i = 0; i < Artikals2.Count; i++)
                {
                    //Artikals2[i].Kupacs.Remove(kupac);
                    //DBAccess.DBAccess.Instance.Artikals.ToList().Find(x => x.Naziv == Artikals2[i].Naziv).Kupacs.Remove(kupac);
                }

                Artikals2 = new List<Artikal>();
                DBAccess.DBAccess.Instance.RacunProcedure((int)sum, Username);

                PayMsg = "Uspesna kupovina!";
            }
            else
            {
                PayMsg = "Nemate dovoljno sredstava za kupovinu!";
            }
            DBAccess.DBAccess.Instance.SaveChanges();
        }

        public void OnBack()
        {
            ViewModelHelper.Instance.CurrentViewModel = new CatalogViewModel();
            RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
        }

        public void OnRemove()
        {
            if (Selected == null)
                ErrorMsg = "Izaberite artikal koji zelite ukloniti";
            else
            {
                Artikal a = DBAccess.DBAccess.Instance.Artikals.ToList().Find(x => x.Naziv == Selected.Naziv);
                Kupac kupac = a.Kupacs.ToList().Find(x => x.Username == Username);

                if (kupac.Username == Username && !String.IsNullOrEmpty(Username))
                {
                    a.Kupacs.Remove(kupac);
                    Artikals2.Remove(a);
                    // OnPropertyChanged("Artikals2");
                    ErrorMsg = "Uspesno brisanje artikla.";
                }
                else
                {
                    ErrorMsg = "Neuspesno brisanje iz korpe!";
                }
                DBAccess.DBAccess.Instance.SaveChanges();
            }
        }

        #region Propreties

        public String Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                OnPropertyChanged("Sum");
            }
        }

        public string Racun
        {
            get
            {
                return String.Format("{0} RSD", RegisterViewModel.CurrentUser.Kupac.Racun);
            }
            set
            {
                racun = value;
                OnPropertyChanged("Racun");
            }
        }

        public string PayMsg
        {
            get { return payMsg; }
            set
            {
                payMsg = value;
                OnPropertyChanged("PayMsg");
            }
        }

        public Artikal Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }

        public string ErrorMsg
        {
            get { return errorMsg; }
            set
            {
                errorMsg = value;
                OnPropertyChanged("ErrorMsg");
            }
        }

        public List<Artikal> Artikals2
        {
            get { return artikals; }
            set
            {
                artikals = value;
                OnPropertyChanged("Artikals2");
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
