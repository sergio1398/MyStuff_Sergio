using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

namespace MyStuff_Sergio.Models
{
    public partial class Currency
    {

        public Currency()
        {
            Items = new HashSet<Item>();
        }

        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySym { get; set; }

        public virtual ICollection<Item> Items { get; set; }


        public ObservableCollection<Currency> GetCurrency()
        {
            ObservableCollection<Currency> Currency = null;

            string Ruta = string.Format("currencies");

            string RutaConsumo = ObjetosGlobales.RutaProduccion + Ruta;

            var MyCurrency = new RestClient(RutaConsumo);

            var Request = new RestRequest(Method.GET);

            Request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);

            IRestResponse Response = MyCurrency.Execute(Request);

            HttpStatusCode CodigoRespuesta = Response.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.OK)
            {
                Currency = JsonConvert.DeserializeObject<ObservableCollection<Currency>>(Response.Content);

                return Currency;
            }

            return Currency;
        
        }

    }
}
