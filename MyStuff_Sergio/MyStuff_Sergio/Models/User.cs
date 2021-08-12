using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace MyStuff_Sergio.Models
{
    public partial class User
    {

        public User()
        {
            Brands = new HashSet<Brand>();
            ItemCategories = new HashSet<ItemCategory>();
            ItemLocalizations = new HashSet<ItemLocalization>();
            Items = new HashSet<Item>();
            Suppliers = new HashSet<Supplier>();

            // ll;evan valores por defecto ya que no se permiten nulos 
            UserStatusId = 1;

            LastLogin = DateTime.Now.Date;
        }


        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string UserPassword { get; set; }
        public string Phone { get; set; }
        public string BackupEmail { get; set; }
        public DateTime LastLogin { get; set; }
        public int UserStatusId { get; set; }

        public virtual UserStatus UserStatus { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<ItemCategory> ItemCategories { get; set; }
        public virtual ICollection<ItemLocalization> ItemLocalizations { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }

        // escribimos las funciones comunicacion de la API
        //se deben explicar en los diagramas de caso de uso

        //funcion para agregar un usuario para agregar a la BD siguiendo la dinmamica del diagrama de Casos de uso 
        //primero se debe quitar si el usuario que estamos por agregar ya existe o no 
        //NOTA> esta consulta se puede hacer en "caliente" al momento de digitar el correo del usuario en el UI

        public async Task<bool> GuardarUsuario()
        {

            bool R = false;
            //se toma la info base de la ruta del API y se agrega el sufijo correspondientepara completar vla ruta de consumo
            //paso 1.3.3.1 ejemplo de secuencia

            string RutaConsumo = ObjetosGlobales.RutaProduccion + "users";

            var client = new RestClient(RutaConsumo);

            var request = new RestRequest(Method.POST);

            // se garega la info de seguridad

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-Type","application/json");

            // ahora serializamos esta clase ya que se ha definido que se va a enviar un json

            string ClaseEnJson = JsonConvert.SerializeObject(this);

            request.AddParameter("application/json",ClaseEnJson,ParameterType.RequestBody);

            //ejecuta de forma asincrona el proceso

            IRestResponse Respuesta = await client.ExecuteAsync(request);

            HttpStatusCode CodigoRespuesta = Respuesta.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.Created)
            {
                R = true;
            }

            return R;
        
        
        }


        public async Task<bool> ValidarUsuario()
        {

            bool R = false;
            //se toma la info base de la ruta del API y se agrega el sufijo correspondientepara completar vla ruta de consumo
            //paso 1.3.3.1 ejemplo de secuencia

            string Ruta = string.Format("Users/ValidateUser2?email={0}&password={1}", this.Username,this.UserPassword);

            //string SufijoRuta = string.Format("users/{0}/{1}", Username, UserPassword);

            string RutaConsumo = ObjetosGlobales.RutaProduccion + Ruta;

            var client = new RestClient(RutaConsumo);

            var request = new RestRequest(Method.GET);

            // se garega la info de seguridad

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);

            //ejecuta de forma asincrona el proceso

            IRestResponse Respuesta = await client.ExecuteAsync(request);

            HttpStatusCode CodigoRespuesta = Respuesta.StatusCode;

            if (CodigoRespuesta == HttpStatusCode.OK)
            {
                ObjetosGlobales.MiUsusarioGlobal = JsonConvert.DeserializeObject<User>(Respuesta.Content);

                R = true;
            }

            return R;


        }


    }



}
