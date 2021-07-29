using System;
using System.Collections.Generic;
using System.Text;
using MyStuff_Sergio.Models;
using System.Threading.Tasks;
using MyStuff_Sergio.Clases;

namespace MyStuff_Sergio.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyUser = new User();

            //TODO: implementar los comandos correspondientes 

        }

        //ahora se implementa la funcion para ser consumida desde la vista 

        public async Task<bool> GuardarUsuario(string Pusername, string Pname, string PuserPassword, string Pphone, string PbackupEmail)
        {
            Crypto Encriptar = new Crypto();

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                
                MyUser.Username = Pusername;// este es el email del usuario
                MyUser.Name = Pname;

                MyUser.UserPassword = Encriptar.EncriptarEnUnSentido(PuserPassword);
                MyUser.Phone = Pphone;
                MyUser.BackupEmail = PbackupEmail;

                bool R = await MyUser.GuardarUsuario();

                return R;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }


        }


        public async Task<bool> ValidarUsuario(string Pusername, string PuserPassword)
        {
            Crypto Encriptar = new Crypto();

            if (IsBusy) return false;

            IsBusy = true;

            try
            {

                MyUser.Username = Pusername;

                MyUser.UserPassword = Encriptar.EncriptarEnUnSentido(PuserPassword);
        

                bool R = await MyUser.ValidarUsuario();

                return R;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                IsBusy = false;
            }


        }







    }
}
