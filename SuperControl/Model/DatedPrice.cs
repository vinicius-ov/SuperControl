using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SuperControl.Model
{
    public class DatedPrice : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date == value)
                {
                    return;
                }
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price == value)
                {
                    return;
                }
                OnPropertyChanged(nameof(Price));
            }
        }
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public DatedPrice(DateTime date, decimal price)
        {
            Date = date;
            Price = price;
        }
        public DatedPrice()
        {
            Date = DateTime.Now;
            Price = new decimal(0.0);
        }
    }
}