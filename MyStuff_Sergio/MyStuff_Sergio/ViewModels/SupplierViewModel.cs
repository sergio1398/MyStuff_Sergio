using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MyStuff_Sergio.Models;
using System.Threading.Tasks;

namespace MyStuff_Sergio.ViewModels
{
    public class SupplierViewModel : BaseViewModel
    {
        public Supplier MySupplier { get; set; }

        public ObservableCollection<Supplier> OCSupplier { get; set; }

        public SupplierViewModel()
        {
            MySupplier = new Supplier();
        }

        public ObservableCollection<Supplier> GetSuppliersVM()
        {

            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                return OCSupplier = new ObservableCollection<Supplier>(MySupplier.GetSuppliers());
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

        public async Task<bool> GuardarMySupplier(string pSupplierName, string pSupplierPhone, string pSupplierEmail, int pUserId)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                //MySupplier.SupplierId = pSupplierId;
                MySupplier.SupplierName = pSupplierName;
                MySupplier.SupplierPhone = pSupplierPhone;
                MySupplier.SupplierEmail = pSupplierEmail;
                MySupplier.UserId = pUserId;

                bool R = await MySupplier.GuardarSupplier();

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

        public async Task<bool> EditarMySupplier(int pSupplierId, string pSupplierName, string pSupplierPhone, string pSupplierEmail, int pUserId)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MySupplier.SupplierId = pSupplierId;
                MySupplier.SupplierName = pSupplierName;
                MySupplier.SupplierPhone = pSupplierPhone;
                MySupplier.SupplierEmail = pSupplierEmail;
                MySupplier.UserId = pUserId;

                bool R = await MySupplier.EditarSupplier();

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

        public async Task<bool> EliminarMySupplier(int pSupplierId)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MySupplier.SupplierId = pSupplierId;

                bool R = await MySupplier.EliminarSupplier();

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
