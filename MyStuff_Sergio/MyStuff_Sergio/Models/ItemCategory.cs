using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyStuff_Sergio.Models
{
    public partial class ItemCategory
    {



        public ItemCategory()
        {
            Items = new HashSet<Item>();
        }



        public int ItemCategoryId { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }



        public ObservableCollection<ItemCategory> ObtenerItemCategories()
        {
            ObservableCollection<ItemCategory> categoriasItem = null;


            string Ruta = string.Format("itemcategories");

            string RutaConsumo = ObjetosGlobales.RutaProduccion + Ruta;

            var itemCategories = new RestClient(RutaConsumo);

            var request = new RestRequest(Method.GET);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);

            IRestResponse Respuesta = itemCategories.Execute(request);

            HttpStatusCode CodigoRespuesta = Respuesta.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.OK)
            {

                categoriasItem = JsonConvert.DeserializeObject<ObservableCollection<ItemCategory>>(Respuesta.Content);

                return categoriasItem;
            }

          

            return categoriasItem;

        }

        public async Task<bool> GuardarItemCategoria()
        {

            bool R = false;
            //se toma la info base de la ruta del API y se agrega el sufijo correspondientepara completar vla ruta de consumo
            //paso 1.3.3.1 ejemplo de secuencia

            string RutaConsumo = ObjetosGlobales.RutaProduccion + "itemCategories";

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

        public async Task<bool> EditarItemCategoria()
        {

            bool R = false;

            string RutaConsumo = string.Format(ObjetosGlobales.RutaProduccion + "itemCategories/{0}", ItemCategoryId);

            var ItemCategoria = new RestClient(RutaConsumo);

            var request = new RestRequest(method: Method.PUT);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-Type", "application/json");

            string Body = JsonConvert.SerializeObject(this);

            request.AddParameter("application/json", Body, ParameterType.RequestBody);

            IRestResponse respuesta = await ItemCategoria.ExecuteAsync(request);

            HttpStatusCode CodigoDeRespuesta = respuesta.StatusCode;

            if (CodigoDeRespuesta == HttpStatusCode.NoContent)
            {
                R = true;
            }


            return R;

        }

        public async Task<bool> EliminarItemCategory()
        {

            bool R = false;

            string RutaConsumo = string.Format(ObjetosGlobales.RutaProduccion + "itemCategories/{0}", ItemCategoryId);

            var ItemCategoria = new RestClient(RutaConsumo);

            var request = new RestRequest(method: Method.DELETE);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-Type", "application/json");


            request.AddParameter("application/json", ParameterType.RequestBody);

            IRestResponse respuesta = await ItemCategoria.ExecuteAsync(request);

            HttpStatusCode CodigoDeRespuesta = respuesta.StatusCode;

            if (CodigoDeRespuesta == HttpStatusCode.NoContent)
            {
                R = true;
            }


            return R;

        }






    }
}
