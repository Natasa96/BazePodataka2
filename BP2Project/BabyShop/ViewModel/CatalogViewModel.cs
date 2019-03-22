using BabyShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BabyShop.ViewModel
{
    public class CatalogViewModel : BindableBase
    {
        private List<ArtikalAdapter> artikals = new List<ArtikalAdapter>();
        private ArtikalAdapter selected = new ArtikalAdapter();
        public MyICommand ProfileCommand { get; set; }
        public MyICommand KorpaCommand { get; set; }

        public CatalogViewModel()
        {
            LoadItems();
            ViewModelHelper.Instance.CurrentViewModel = this;
            ProfileCommand = new MyICommand(OnProfile);
            KorpaCommand = new MyICommand(OnKorpa);
        }

        public void OnKorpa()
        {
            DBAccess.DBAccess.Refresh();
            ViewModelHelper.Instance.CurrentViewModel = new ShoppingCartViewModel();
            RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
        }

        public void OnProfile()
        {
            DBAccess.DBAccess.Refresh();
            ViewModelHelper.Instance.CurrentViewModel = new ProfileViewModel();
            RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
        }

        public void LoadItems()
        {
            foreach (var item in DBAccess.DBAccess.Instance.Artikals)
            {
                Artikals.Add(new ArtikalAdapter() {
                    Name = item.Naziv,
                    Price = (double)item.Cena,
                    Path = item.Slika,
                    Desc = item.Opis
                });
            }
        }

        public List<ArtikalAdapter> Artikals
        {
            get { return artikals; }
            set
            {
                artikals = value;
                OnPropertyChanged("Artikals");
            }
        }

        public ArtikalAdapter Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
                ViewModelHelper.Instance.CurrentViewModel = new ItemViewModel();
                ViewModelHelper.selected = new ArtikalAdapter()
                {
                    Desc = selected.Desc,
                    Name = selected.Name,
                    Path = selected.Path,
                    Price = selected.Price
                };
                RaisePropertyChanged(ViewModelHelper.Instance.MainViewModel, "CurrentViewModel");
            }
        }
    }
}
