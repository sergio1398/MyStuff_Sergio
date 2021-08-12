using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MyStuff_Sergio.Models;
using MyStuff_Sergio.ViewModels;

namespace MyStuff_Sergio.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        public ItemCategoryViewModel MiItemcategoriaVM { get; set; } // se trae desde el view model de la marca 
        public ObservableCollection<ItemCategory> Tiposs { get; set; }

        public BrandViewModel MiMarcaVM { get; set; }// se trae desde el view model de la marca r
        public ObservableCollection<Brand> MyBrands { get; set; }


        public ItemLocalizationViewModel MyItemLocalizationVM { get; set; } // cambio a VM 
        public ObservableCollection<ItemLocalization> ItemLocalizationss { get; set; }


        public SupplierViewModel MySupplier { get; set; }// cambio a VM 
        public ObservableCollection<Supplier> Supplier { get; set; }


        public Currency MyCurrency { get; set; }
        public ObservableCollection<Currency> Currency { get; set; }

        public Item MyItem { get; set; }


        public ItemViewModel()
        {
            MiItemcategoriaVM = new ItemCategoryViewModel();// este es VM
            MiMarcaVM = new BrandViewModel();// solo esta es ViewModel
            MyItemLocalizationVM = new ItemLocalizationViewModel();
            MySupplier = new SupplierViewModel();
            MyCurrency = new Currency();
            MyItem = new Item();


            ObtenerCategoria();
            ObtenerMarcass();
            GetItemLocalization();
            GetSupplierss();
            GetCurrency();

        }

        public async Task<bool> GurdarItem(string nombre, string descripcion, decimal costo, string numeroSerie, string numFactura, decimal depreciacion,
                                           int pMarcaId, int CategoriaItemId, int LocalizacionItemId, int ProveedorId, int MonedaID, string ImagenItem)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MyItem.ItemName = nombre;
                MyItem.ItemDescription = descripcion;// este dato está quemado pero luego hay que utilizar un picker
                MyItem.ItemCost = costo;
                MyItem.SerialNumber = numeroSerie;
                MyItem.InvoiceNumber = numFactura;
                MyItem.ExRate = depreciacion;
                MyItem.BrandId = pMarcaId;
                MyItem.ItemCategoryId = CategoriaItemId;
                MyItem.ItemLocalizationId = LocalizacionItemId;
                MyItem.SupplierId = ProveedorId;
                MyItem.UserId = ObjetosGlobales.MiUsusarioGlobal.UserId;
                MyItem.CurrencyId = MonedaID;
                MyItem.DisplayImageUri = ImagenItem;
                bool R = await MyItem.GuardarItem();

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

        public ObservableCollection<Supplier> GetSupplierss()
        {

            return Supplier = new ObservableCollection<Supplier>(MySupplier.GetSuppliersVM());

        }

        public ObservableCollection<ItemLocalization> GetItemLocalization()
        {

            return ItemLocalizationss = new ObservableCollection<ItemLocalization>(MyItemLocalizationVM.GetItemLocalization());

        }

        public ObservableCollection<Brand> ObtenerMarcass()
        {

            return MyBrands = new ObservableCollection<Brand>(MiMarcaVM.ObtenerMarcas());

        }

        public ObservableCollection<ItemCategory> ObtenerCategoria()
        {

            return Tiposs = new ObservableCollection<ItemCategory>(MiItemcategoriaVM.ObtenerItemCategory());

        }

    }
}
