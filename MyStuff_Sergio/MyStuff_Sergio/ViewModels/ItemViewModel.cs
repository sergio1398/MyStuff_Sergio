using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MyStuff_Sergio.Models;

namespace MyStuff_Sergio.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        public ItemCategory MiItemcategoria { get; set; }

        public ObservableCollection<ItemCategory> Tiposs { get; set; }


        public ItemViewModel()
        {
            MiItemcategoria = new ItemCategory();
            ObtenerCategoria();

        }

        public ObservableCollection<ItemCategory> ObtenerCategoria()
        {
            

            if (IsBusy) return null;
            IsBusy = true;

            try
            {

             return Tiposs = new ObservableCollection<ItemCategory>(MiItemcategoria.ObtenerItemCategories());

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

    }
}
