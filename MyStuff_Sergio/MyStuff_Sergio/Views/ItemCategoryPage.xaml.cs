using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyStuff_Sergio.ViewModels;
using MyStuff_Sergio.Models;

namespace MyStuff_Sergio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemCategoryPage : ContentPage
    {

        ItemCategoryViewModel MyItemCategory;

        public ItemCategoryPage()
        {
            InitializeComponent();
            BindingContext = MyItemCategory = new ItemCategoryViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LstItemCategories.ItemsSource = MyItemCategory.ObtenerItemCategory();
        }

        private void BtnAgregarItemCategory_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarItemCategoryPage());
        }

        private void LstItemCategories_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ItemCategory MyItemCategory = e.Item as ItemCategory;
            EditarItemCategoryPage editarItemCategory = new EditarItemCategoryPage();
            editarItemCategory.BindingContext = MyItemCategory;
            Navigation.PushAsync(editarItemCategory);
        }
    }
}