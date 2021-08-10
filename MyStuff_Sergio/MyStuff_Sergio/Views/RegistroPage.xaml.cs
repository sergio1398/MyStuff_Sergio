using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyStuff_Sergio.ViewModels;
using MyStuff_Sergio.Clases;

namespace MyStuff_Sergio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {

        UserViewModel UsuarioVM;

        public RegistroPage()
        {
            InitializeComponent();

            BindingContext = UsuarioVM = new UserViewModel();

        }

        private async void CmdCancelar(object sender, EventArgs e)
        {
            _ = await Navigation.PopAsync();
        }

        private bool EmailCorrecto(string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    return Herramientas.ValidarEmail(email);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
           
        }

        private bool ContraCorrecto()
        {
            try
            {
                bool R = false;

                if (!string.IsNullOrEmpty(TxtPassword.Text.Trim()) && !string.IsNullOrEmpty(TxtPassword2.Text.Trim()))
                {
                    if (TxtPassword.Text.Trim() == TxtPassword2.Text.Trim())
                    {
                        R = true;
                    }

                }

                return R;
            }
            catch (Exception)
            {
                return false;
                throw;

            }
           
        }

        private bool ValidarCampos()
        {

            
            bool R = false;


            try
            {

                if (!string.IsNullOrEmpty(TxtUsuario.Text.Trim()) &&
                     !string.IsNullOrEmpty(TxtNombreUsuario.Text.Trim()) &&
                     !string.IsNullOrEmpty(TxtPassword.Text.Trim()) &&
                     !string.IsNullOrEmpty(TxtPassword2.Text.Trim()) &&
                     !string.IsNullOrEmpty(NumeroTelefono.Text.Trim()) &&
                     !string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()))
                {

                    R = true;

                }

                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }


        private async void CmdAceptar(object sender, EventArgs e)
        {

            // primero se tienen que validar el correo con su formato adecuado y además que las contraseñas sean iguales

            if (ValidarCampos())
            {


                if (EmailCorrecto(TxtUsuario.Text.Trim()) &&
                    EmailCorrecto(TxtBackUpEmail.Text.Trim()) &&
                    ContraCorrecto())
                {
                    

                    bool R =  await UsuarioVM.GuardarUsuario(TxtUsuario.Text.Trim(), TxtNombreUsuario.Text.Trim(), TxtPassword.Text.Trim(), NumeroTelefono.Text.Trim(), TxtBackUpEmail.Text.Trim());

                    if (R)
                    {
                        await DisplayAlert("Aviso", "Usuario agregado correctamente", "OK");

                        await Navigation.PopAsync();
                        
                    }
                    else
                    {
                        await DisplayAlert("Aviso", "Error el usuario no se agregó", "OK");
                        
                    }

                }
                else
                {
                    if (!EmailCorrecto(TxtUsuario.Text.Trim()))
                    {
                        await DisplayAlert("Aviso", "Error el email no se ingresó con el formato incorrecto", "OK");
                        
                        return;
                    }

                    if (!EmailCorrecto(TxtBackUpEmail.Text.Trim()))
                    {
                        await DisplayAlert("Aviso", "Error el email de respaldo no se ingresó con el formato incorrecto", "OK");
                        
                        return;
                    }

                    if (!ContraCorrecto())
                    {
                        await DisplayAlert("Aviso", "Error las contraseñas no son iguales, intentélo de nuevo", "OK");
                        
                        return;
                    }

                }

            }
            else
            {
                await DisplayAlert("Aviso", "Los campos no pueden estar vacios, por favor ingreselos nuevamente", "OK");
               
            }



        }
    }
}