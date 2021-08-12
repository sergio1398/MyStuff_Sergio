using System;
using System.Collections.Generic;
using System.Text;
using MyStuff_Sergio.Models;

namespace MyStuff_Sergio
{
    public class ObjetosGlobales
    {

        public static string RutaProduccion = "http://192.168.0.14:45455/api/"; ///
        public static string RutaPrueba = "http://192.168.0.14:45455/api/";

        //agregamos la info de seguridad ya sea JWT o ApiKey como en este caso

        public static string ApiKeyName = "ApiKey";
        public static string ApiKeyValue = "123QWE";
        public static User MiUsusarioGlobal { get; set; }


    }
}
