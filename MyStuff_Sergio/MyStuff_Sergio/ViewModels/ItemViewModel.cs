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

        public Brand MiMarca { get; set; }
        public ObservableCollection<Brand> MyBrands { get; set; }

        public ItemLocalization MyItemLocalization { get; set; }
        public ObservableCollection<ItemLocalization> ItemLocalizationss { get; set; }

        public Supplier MySupplier { get; set; }
        public ObservableCollection<Supplier> Supplier { get; set; }

        public Currency MyCurrency { get; set; }
        public ObservableCollection<Currency> Currency { get; set; }

        public Item MyItem { get; set; }

        public ItemViewModel()
        {
            MiItemcategoria = new ItemCategory();
            MiMarca = new Brand();
            MyItemLocalization = new ItemLocalization();
            MySupplier = new Supplier();
            MyCurrency = new Currency();
            MyItem = new Item();

            ObtenerCategoria();
            ObtenerMarcas();
            GetItemLocalization();
            GetSuppliers();
            GetCurrency();

        }

        public ObservableCollection<Item> ListarItems()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                return MyItem.ListarItems();
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


        public ObservableCollection<Currency> GetCurrency()
        {

            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                return Currency = new ObservableCollection<Currency>(MyCurrency.GetCurrency());
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

        public ObservableCollection<Supplier> GetSuppliers()
        {

            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                return Supplier = new ObservableCollection<Supplier>(MySupplier.GetSuppliers());
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

        public ObservableCollection<ItemLocalization> GetItemLocalization()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                return ItemLocalizationss = new ObservableCollection<ItemLocalization>(MyItemLocalization.ObtenerLocalizacionItem());
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

        public ObservableCollection<Brand> ObtenerMarcas()
        {

            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                return MyBrands = new ObservableCollection<Brand>(MiMarca.ObtenerBrands());
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
