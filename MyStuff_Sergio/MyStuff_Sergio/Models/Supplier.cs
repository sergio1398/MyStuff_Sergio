using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

namespace MyStuff_Sergio.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Items = new HashSet<Item>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }


        public ObservableCollection<Supplier> GetSuppliers()
        {
            ObservableCollection<Supplier> Suppliers = null;

            String Ruta = string.Format("Suppliers");

            String RutaConsumo = ObjetosGlobales.RutaProduccion + Ruta;

            var MySupplier = new RestClient(RutaConsumo);

            var Request = new RestRequest(Method.GET);

            Request.AddHeader(ObjetosGlobales.ApiKeyName,ObjetosGlobales.ApiKeyValue);

            IRestResponse Response = MySupplier.Execute(Request);

            HttpStatusCode CodigoRespuesta = Response.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.OK)
            {

                Suppliers = JsonConvert.DeserializeObject<ObservableCollection<Supplier>>(Response.Content);

                return Suppliers;

            }


            return Suppliers;

        }




    }
}
