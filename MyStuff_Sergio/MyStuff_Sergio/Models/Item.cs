using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MyStuff_Sergio.Models
{
    public partial class Item
    {
        public Item()
        {
            Multimedia = new HashSet<Multimedium>();
        }

        public string DisplayPhoto { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemCost { get; set; }
        public string SerialNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal ExRate { get; set; }
        public int? BrandId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? ItemLocalizationId { get; set; }
        public int? SupplierId { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public string DisplayImageUri { get; set; }
        public string DisplayImageUrilowRes { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemLocalization ItemLocalization { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Multimedium> Multimedia { get; set; }





        public ObservableCollection<Item> ListarItems()
        {

            ObservableCollection<Item> ListaItems = null;

            string Ruta = string.Format("Items/GetItemsList?UserId={0}", this.UserId);

            string RutaConsumo = ObjetosGlobales.RutaProduccion + Ruta;

            var MyItems = new RestClient(RutaConsumo);

            var Request = new RestRequest(Method.GET);

            Request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);

            IRestResponse Response = MyItems.Execute(Request);

            HttpStatusCode CodigoRespuesta = Response.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.OK)
            {
                return ListaItems = JsonConvert.DeserializeObject<ObservableCollection<Item>>(Response.Content);
                
            }

            return ListaItems;

        }

        public async Task<bool> GuardarItem()
        {

            bool R = false;
            //se toma la info base de la ruta del API y se agrega el sufijo correspondientepara completar vla ruta de consumo
            //paso 1.3.3.1 ejemplo de secuencia

            string RutaConsumo = ObjetosGlobales.RutaProduccion + "items";

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






    }
}