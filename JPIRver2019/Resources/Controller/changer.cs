using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JPIRver2019.Resources.Controller
{
    class changer
    {
        public void changerStatus(string x)
        {
            var statusSwitch = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), x);


            switch (statusSwitch)
            {
                case HttpStatusCode.OK:
                    Settings.estado = "Conectada";
                    break;
                case HttpStatusCode.Unauthorized:
                    Settings.estado = "Error en el usuario";
                    break;
                case HttpStatusCode.RequestTimeout:
                case HttpStatusCode.GatewayTimeout:
                    Settings.estado = "Servidor inalcanzable";
                    break;
                case HttpStatusCode.Forbidden:
                    Settings.estado = "No se encuentra AP";
                    break;
                case HttpStatusCode.Conflict:
                    Settings.estado = "AP sin zona";
                    break;
                default:
                    Settings.estado = "Error interno en el servidor";
                    break;
            }
        }
    }
}