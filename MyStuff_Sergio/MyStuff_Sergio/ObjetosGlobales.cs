﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyStuff_Sergio
{
    class ObjetosGlobales
    {

        public static string RutaProduccion = "http://172.25.176.1:45455/api/"; ///
        public static string RutaPrueba = "http://172.25.176.1:45455/api/";

        //agregamos la info de seguridad ya sea JWT o ApiKey como en este caso

        public static string ApiKeyName = "ApiKey";
        public static string ApiKeyValue = "123QWE";

    }
}
