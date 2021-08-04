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




    }
}
