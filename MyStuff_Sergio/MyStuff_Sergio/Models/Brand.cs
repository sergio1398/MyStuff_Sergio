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

            string Ruta = string.Format("brands");

            string RutaConsumo = ObjetosGlobales.RutaProduccion + Ruta;

            var Marcas = new RestClient(RutaConsumo);

            var Request = new RestRequest(Method.GET);

            Request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);

            IRestResponse Response = Marcas.Execute(Request);

            HttpStatusCode CodigoRespuesta = Response.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.OK)
            {
                        
                return JsonConvert.DeserializeObject<ObservableCollection<Brand>>(Response.Content); 

            }
            return null;

        }


        public async Task<bool> GuardarBrand()
        {

            bool R = false;
            //se toma la info base de la ruta del API y se agrega el sufijo correspondientepara completar vla ruta de consumo
            //paso 1.3.3.1 ejemplo de secuencia

            string RutaConsumo = ObjetosGlobales.RutaProduccion + "brands";

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


        public async Task<bool> EditarBrand()
        {

            bool R = false;

            string RutaConsumo = string.Format(ObjetosGlobales.RutaProduccion + "brands/{0}", BrandId);

            var Marca = new RestClient(RutaConsumo);

            var request = new RestRequest(method: Method.PUT);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-Type", "application/json");

            string Body = JsonConvert.SerializeObject(this);

            request.AddParameter("application/json", Body, ParameterType.RequestBody);

            IRestResponse respuesta = await Marca.ExecuteAsync(request);

            HttpStatusCode CodigoDeRespuesta = respuesta.StatusCode;

            if (CodigoDeRespuesta == HttpStatusCode.NoContent)
            {
                R = true;
            }

            
            return R;

        }

        public async Task<bool> EliminarBrand()
        {

            bool R = false;

            string RutaConsumo = string.Format(ObjetosGlobales.RutaProduccion + "brands/{0}", BrandId);

            var Marca = new RestClient(RutaConsumo);

            var request = new RestRequest(method: Method.DELETE);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-Type", "application/json");


            request.AddParameter("application/json", ParameterType.RequestBody);

            IRestResponse respuesta = await Marca.ExecuteAsync(request);

            HttpStatusCode CodigoDeRespuesta = respuesta.StatusCode;

            if (CodigoDeRespuesta == HttpStatusCode.NoContent)
            {
                R = true;
            }


            return R;

        }





    }

}
