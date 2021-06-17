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
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void CmdCancelar(object sender, EventArgs e)
        {
            _ = await Navigation.PopAsync();
        }

        private void CmdAceptar(object sender, EventArgs e)
        {

        }
    }
}