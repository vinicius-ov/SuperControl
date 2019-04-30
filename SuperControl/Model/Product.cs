using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SuperControl.Model
{
    public class Product : INotifyPropertyChanged
    {
        string name = string.Empty;
        public String DisplayName
        {
            get => name;
            set
            {
                if (name == value)
                {
                    return;
                }
                name = value;
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public List<DatedPrice> Prices { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public double LowestPrice
        {
            get
            {
                return Prices.Min(t => t.Price);
            }
        }
        public double HighestPrice
        {
            get
            {
                return Prices.Max(t => t.Price);
            }
        }
        public Product()
        {
            Prices = new List<DatedPrice>();
        }
    }
}