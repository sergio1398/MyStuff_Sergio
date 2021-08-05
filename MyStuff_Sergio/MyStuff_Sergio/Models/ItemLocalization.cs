using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using RestSharp;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MyStuff_Sergio.Models
{
   public partial class ItemLocalization
    {
        public ItemLocalization()
        {
            Items = new HashSet<Item>();
        }

        public int ItemLocalizationId { get; set; }
        public string Localization { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }


        public ObservableCollection<ItemLocalization> ObtenerLocalizacionItem()
        {

            ObservableCollection<ItemLocalization> Localizacion = null;

            string Ruta = string.Format("ItemLocalizations");

            string RutaConsumo = ObjetosGlobales.RutaProduccion + Ruta;

            var ItemLocalization = new RestClient(RutaConsumo);

            var Request = new RestRequest(Method.GET);

            Request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);

            IRestResponse Response = ItemLocalization.Execute(Request);

            HttpStatusCode CodigoRespuesta = Response.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.OK)
            {
                Localizacion = JsonConvert.DeserializeObject<ObservableCollection<ItemLocalization>>(Response.Content);

                return Localizacion;
            }

            return Localizacion;
        
        
        }







    }
}
