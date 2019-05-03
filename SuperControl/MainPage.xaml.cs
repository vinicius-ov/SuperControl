using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SuperControl.Model;

namespace SuperControl
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Product> products = new ObservableCollection<Product>();
        Product selected;
        DatedPrice datePrice = new DatedPrice();
        double price = 0.0;
        public MainPage()
        {
            InitializeComponent();
            ProductsListView.ItemsSource = products;
            NameEntry.Keyboard = Keyboard.Create(KeyboardFlags.Suggestions | KeyboardFlags.CapitalizeWord);
            PriceEntry.BindingContext = datePrice;
            DateEntry.BindingContext = datePrice;
            
        }

        public void OnSaveProduct(object sender, EventArgs args)
        {
            int index = 0;
            DateTime date = DateEntry.Date;
            double price = double.Parse(PriceEntry.Text);
            DatedPrice datePrice = new DatedPrice(date, new decimal(price));
            Product product = new Product();
            if (selected != null)
            {
                product = selected;
                index = products.IndexOf(product);
                products.Remove(product);
            }
            product.DisplayName = NameEntry.Text;
            product.Prices.Add(datePrice);

            products.Insert(index, product);

            ResetForm();
        }
        public void OnSelectItem(ListView sender, SelectedItemChangedEventArgs args)
        {
            UpsertButton.Text = "EDITAR";
            selected = (Product)args.SelectedItem;
            Console.WriteLine(selected);
            NameEntry.Text = selected.DisplayName;
        }
        public void ResetForm()
        {
            NameEntry.Text = "";
            PriceEntry.Text = "";
            selected = null;
            UpsertButton.Text = "SALVAR";
        }

    }
}
