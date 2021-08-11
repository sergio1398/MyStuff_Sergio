using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using RestSharp;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Threading.Tasks;

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


        public async Task<bool> GuardarItemLocalization()
        {

            bool R = false;

            string RutaConsumo = ObjetosGlobales.RutaProduccion + "ItemLocalizations";

            var client = new RestClient(RutaConsumo);

            var request = new RestRequest(Method.POST);

            // se garega la info de seguridad

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-Type", "application/json");

            // ahora serializamos esta clase ya que se ha definido que se va a enviar un json

            string Body = JsonConvert.SerializeObject(this);

            request.AddParameter("application/json", Body, ParameterType.RequestBody);

            //ejecuta de forma asincrona el proceso

            IRestResponse Respuesta = await client.ExecuteAsync(request);

            HttpStatusCode CodigoRespuesta = Respuesta.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.Created)
            {
                R = true;
            }

            return R;


        }

        public async Task<bool> EditarItemLocalizaion()
        {

            bool R = false;

            string RutaConsumo = string.Format(ObjetosGlobales.RutaProduccion + "ItemLocalizations/{0}", ItemLocalizationId);

            var MyItemlocalization = new RestClient(RutaConsumo);

            var request = new RestRequest(method: Method.PUT);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-Type", "application/json");

            string Body = JsonConvert.SerializeObject(this);

            request.AddParameter("application/json", Body, ParameterType.RequestBody);

            IRestResponse respuesta = await MyItemlocalization.ExecuteAsync(request);

            HttpStatusCode CodigoDeRespuesta = respuesta.StatusCode;

            if (CodigoDeRespuesta == HttpStatusCode.NoContent)
            {
                R = true;
            }


            return R;

        }

        public async Task<bool> EliminarItemLocalization()
        {

            bool R = false;

            string RutaConsumo = string.Format(ObjetosGlobales.RutaProduccion + "ItemLocalizations/{0}", ItemLocalizationId);

            var itemLocalization = new RestClient(RutaConsumo);

            var request = new RestRequest(method: Method.DELETE);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-Type", "application/json");


            request.AddParameter("application/json", ParameterType.RequestBody);

            IRestResponse respuesta = await itemLocalization.ExecuteAsync(request);

            HttpStatusCode CodigoDeRespuesta = respuesta.StatusCode;

            if (CodigoDeRespuesta == HttpStatusCode.NoContent)
            {
                R = true;
            }


            return R;

        }







    }
}
