using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            string statusSwitch = x;

            switch (statusSwitch)
            {
                case "200":
                    Settings.estado = "Conectada";
                    break;
                case "403":
                    Settings.estado = "Error en el usuario";
                    break;

                case "404":
                    Settings.estado = "Servidor inalcanzable";
                    break;

                case "441":
                    Settings.estado = "No se encuentra AP";
                    break;

                case "440":
                    Settings.estado = "AP sin zona";
                    break;

                case "500":
                    Settings.estado = "Error interno en el servidor";
                    break;

                default:

                    break;

            }
        }
    }
}