using MyStuff_Sergio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyStuff_Sergio.ViewModels
{
    public class BrandViewModel : BaseViewModel
    {

        public Brand MiMarca { get; set; }
        public ObservableCollection<Brand> MyBrands { get; set; }


        public BrandViewModel()
        {

            MiMarca = new Brand();

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

        public async Task<bool> GurdarBrand(string pBrandName, int pUserId)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiMarca.BrandName = pBrandName;
                MiMarca.UserId = pUserId;// este dato está quemado pero luego hay que utilizar un picker


                bool R = await MiMarca.GuardarBrand();

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

        public async Task<bool> EditarBrand(int pBrandId, string pBrandName, int UserId)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiMarca.BrandId = pBrandId;
                MiMarca.BrandName = pBrandName;
                MiMarca.UserId = UserId;


                bool R = await MiMarca.EditarBrand();

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


        public async Task<bool>EliminarBrand(int pBrandId)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MiMarca.BrandId = pBrandId;

                bool R = await MiMarca.EliminarBrand();

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
