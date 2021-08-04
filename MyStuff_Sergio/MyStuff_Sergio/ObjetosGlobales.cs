using System;
using System.Collections.Generic;
using System.Text;

namespace MyStuff_Sergio
{
    class ObjetosGlobales
    {

        public static string RutaProduccion = "http://172.27.64.1:45455/api/"; ///http://192.168.0.15:45455/
        public static string RutaPrueba = "http://172.27.64.1:45455/api/";

        //agregamos la info de seguridad ya sea JWT o ApiKey como en este caso

        public static string ApiKeyName = "ApiKey";
        public static string ApiKeyValue = "123QWE";

    }
}
