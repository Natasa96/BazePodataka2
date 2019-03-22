using BabyShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BabyShop.ViewModel
{
    public class ItemViewModel : BindableBase
    {
        private string name;
        private string info;
        private double price;
        private string path;
        public MyICommand BackCommand { get; set; }
        public MyICommand AddCommand { get; set; }

        public ItemViewModel()
        {
            ViewModelHelper.Instance.CurrentViewModel = this;

            Name = ViewModelHelper.selected.Name;
            Info = ViewModelHelper.selected.Desc;
            Price = ViewModelHelper.selected.Price;
            Path = ViewModelHelper.selected.Path;
            BackCommand = new MyICommand(OnBack);
            AddCommand = new MyICommand(OnAdd);
        }

        public void OnAdd()
        {
            try
            {
                Artikal artikal = DBAccess.DBAccess.Instance.Artikals.ToList().Find(x => x.Naziv == Name);
                Kupac kupac = DBAccess.DBAccess.Instance.Kupacs.ToList().Find(x => x.Username == RegisterViewModel.CurrentUser.Username);
                artikal.Kupacs.Add(kupac);
                DBAccess.DBAccess.Instance.SaveChanges();
                DBAccess.DBAccess.Refresh();

                ViewModelHelper.Instance.CurrentViewModel = new ShoppingCartViewModel();
                RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
            }
            catch (Exception e) { }
        }

        public void OnBack()
        {
            ViewModelHelper.Instance.CurrentViewModel = new CatalogViewModel();
            RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
        }

        #region Properties

        public BitmapImage Img
        {
            get
            {
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(Path, UriKind.RelativeOrAbsolute);
                src.EndInit();
                return src;
            }
        }

        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }

        #endregion
    }
}
