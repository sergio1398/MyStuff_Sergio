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
    public partial class AgregarItemPage : ContentPage
    {

        //public ItemViewModel MiItemVM = new ItemViewModel();

        public AgregarItemPage()
        {
            InitializeComponent();
            BindingContext = new ItemViewModel();

        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
           
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}