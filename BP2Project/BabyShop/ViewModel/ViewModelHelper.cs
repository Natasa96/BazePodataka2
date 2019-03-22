using BabyShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyShop.ViewModel
{
    public class ViewModelHelper : BindableBase
    {
        private BindableBase currentViewModel;
        private static ViewModelHelper helper = null;
        private BindableBase mainViewModel;
        private BindableBase catalogViewModel;
        private BindableBase itemViewModel;
        private BindableBase shoppingCartViewModel;
        private BindableBase profileViewModel;
        public static ArtikalAdapter selected = new ArtikalAdapter();

        private ViewModelHelper() { }

        public static ViewModelHelper Instance
        {
            get
            {
                if (helper == null)
                    helper = new ViewModelHelper();

                return helper;
            }
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }

        public BindableBase MainViewModel
        {
            get { return mainViewModel; }
            set { mainViewModel = value; }
        }

        public BindableBase ItemViewModel
        {
            get { return itemViewModel; }
            set { itemViewModel = value; }
        }

        public BindableBase CatalogViewModel
        {
            get { return catalogViewModel; }
            set { catalogViewModel = value; }
        }

        public BindableBase ShoppingCartViewModel
        {
            get { return shoppingCartViewModel; }
            set { shoppingCartViewModel = value; }
        }

        public BindableBase ProfileViewModel
        {
            get { return profileViewModel; }
            set { profileViewModel = value; }
        }
    }
}
