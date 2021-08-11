using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MyStuff_Sergio.Models;

namespace MyStuff_Sergio.ViewModels
{
    public class ItemLocalizationViewModel : BaseViewModel
    {

        public ItemLocalization MyItemLocalizations { get; set; }
        public ObservableCollection<ItemLocalization> ItemLocalizationss { get; set; }

        public ItemLocalizationViewModel()
        {

            MyItemLocalizations = new ItemLocalization();


        }

        public ObservableCollection<ItemLocalization> GetItemLocalization()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                return ItemLocalizationss = new ObservableCollection<ItemLocalization>(MyItemLocalizations.ObtenerLocalizacionItem());
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                IsBusy = false;
            }

        }

        public async Task<bool> GurdarItemLocalizacion(string pLocalization, int pUserId)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MyItemLocalizations.Localization = pLocalization;
                MyItemLocalizations.UserId = pUserId;// este dato está quemado pero luego hay que utilizar un picker


                bool R = await MyItemLocalizations.GuardarItemLocalization();

                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                IsBusy = false;
            }


        }

        public async Task<bool> EditarItemLocallizacion(int pItemLocalizationId, string pLocalization, int pUserId)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MyItemLocalizations.ItemLocalizationId = pItemLocalizationId;
                MyItemLocalizations.Localization = pLocalization;
                MyItemLocalizations.UserId = pUserId;


                bool R = await MyItemLocalizations.EditarItemLocalizaion();

                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                IsBusy = false;
            }


        }

        public async Task<bool> EliminarItemLocalizacion(int pItemLocalizationId)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MyItemLocalizations.ItemLocalizationId = pItemLocalizationId;

                bool R = await MyItemLocalizations.EliminarItemLocalization();

                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                IsBusy = false;
            }


        }








    }
}
