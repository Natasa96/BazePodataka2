using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BabyShop.Model
{
    public class ArtikalAdapter
    {
        private string name;
        private double price;
        private string path;
        private string desc;

        public ArtikalAdapter() { }

        public BitmapImage Img
        {
            get
            {
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                src.EndInit();
                return src;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public string Desc
        {
            get { return desc; }
            set
            {
                desc = value;
                RaisePropertyChanged("Desc");
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                RaisePropertyChanged("Path");
            }
        }
    }
}
