using MyStuff_Sergio.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyStuff_Sergio.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}