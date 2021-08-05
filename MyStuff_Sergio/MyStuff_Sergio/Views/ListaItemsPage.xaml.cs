using MyStuff_Sergio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStuff_Sergio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaItemsPage : ContentPage
    {
        ItemViewModel VmItem;

        public ListaItemsPage()
        {
            InitializeComponent();
            BindingContext = VmItem = new ItemViewModel();
            VmItem.MyItem.UserId = 2005;

            LstItems.ItemsSource = VmItem.ListarItems();
        }

        private void LstItems_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}