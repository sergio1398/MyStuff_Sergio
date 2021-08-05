using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

namespace MyStuff_Sergio.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Items = new HashSet<Item>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }



        public ObservableCollection<Brand> ObtenerBrands()
        {

            ObservableCollection<Brand> marca = null;

            string Ruta = string.Format("brands");

            string RutaConsumo = ObjetosGlobales.RutaProduccion + Ruta;

            var Marcas = new RestClient(RutaConsumo);

            var Request = new RestRequest(Method.GET);

            Request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);

            IRestResponse Response = Marcas.Execute(Request);

            HttpStatusCode CodigoRespuesta = Response.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.OK)
            {

                marca = JsonConvert.DeserializeObject<ObservableCollection<Brand>>(Response.Content);

                return marca;
            }
            return marca;

        }




    }

}
