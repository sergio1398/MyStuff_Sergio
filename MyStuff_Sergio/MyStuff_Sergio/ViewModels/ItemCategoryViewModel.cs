using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MyStuff_Sergio.Models;


namespace MyStuff_Sergio.ViewModels
{
    public class ItemCategoryViewModel : BaseViewModel
    {

        ItemCategory MiItemcategoria;
        ObservableCollection<ItemCategory> Tipos;

        public ItemCategoryViewModel()
        {
            MiItemcategoria = new ItemCategory();
        }

        public ObservableCollection<ItemCategory> ObtenerItemCategory()
        {


            if (IsBusy) return null;
            IsBusy = true;

            try
            {

                return Tipos = new ObservableCollection<ItemCategory>(MiItemcategoria.ObtenerItemCategories());

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

        public async Task<bool> GurdarItemCategoria(string pCategory, int pUserId)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiItemcategoria.Category = pCategory;
                MiItemcategoria.UserId = pUserId;// este dato está quemado pero luego hay que utilizar un picker


                bool R = await MiItemcategoria.GuardarItemCategoria();

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

        public async Task<bool> EditarItemCategoria(int pItemCategoryId, string pCategory, int pUserId)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiItemcategoria.ItemCategoryId = pItemCategoryId;
                MiItemcategoria.Category = pCategory;
                MiItemcategoria.UserId = pUserId;


                bool R = await MiItemcategoria.EditarItemCategoria();

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

        public async Task<bool> EliminarItemCategoria(int pItemCategoryId)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiItemcategoria.ItemCategoryId = pItemCategoryId;

                bool R = await MiItemcategoria.EliminarItemCategory();

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
