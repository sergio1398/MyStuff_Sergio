using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyStuff_Sergio.ViewModels;

namespace MyStuff_Sergio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresoPage : ContentPage
    {
        UserViewModel Vm;

        public IngresoPage()
        {
            InitializeComponent();
            BindingContext = Vm = new UserViewModel();
        }

        private void CmdVerPassword(object sender, ToggledEventArgs e)
        {
            if (SwVerPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void CmdIngresar(object sender, EventArgs e)
        {
            bool R = await Vm.ValidarUsuario(TxtUsuario.Text.Trim(), TxtPassword.Text.Trim());

            if (R)
            {
                //await DisplayAlert("Bienvenido", "Usuario correcto","OK");
                await Navigation.PushAsync(new SelectorAccionPage());

            }
            else
            {
                await DisplayAlert("Error", "Usuario incorrecto", "OK");
            }


        }

        private async void CmdRegistarse(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage());
        }
    }
}