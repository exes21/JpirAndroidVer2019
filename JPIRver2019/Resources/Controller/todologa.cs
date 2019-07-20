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
    class todologa
    {
        public void request(Context context)
        {
            ArmaJson miJson = new ArmaJson();
            ManegadorWifi manejador = new ManegadorWifi();
            int uno = manejador.getLinkSpeed(context);
            int dos = manejador.getSignLevel(context);
            string tres = manejador.getSSID(context);
            string cuatro = manejador.getGateway(context).ToString();
            string MacAddress1 = manejador.getMacAddreess(context);
            string macRouter = manejador.macDelRouter(context);

            miJson.armarAsync(uno, dos, tres, cuatro, MacAddress1, macRouter);
        }
    }
}