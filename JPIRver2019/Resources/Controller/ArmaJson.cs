using System;
using System.Threading;
using System.Timers;
using Java.Util;
using JPIRver2019.Resources.controller;
using Plugin.Geolocator.Abstractions;


namespace JPIRver2019.Resources.Controller
{
    class ArmaJson
    {
        EnviaJson envia = new EnviaJson();
         
        public async System.Threading.Tasks.Task armarAsync()
        {
            Console.WriteLine("voy a medir");
            geo _geo = new geo();
   
            Position _position = await _geo.GetPosition();

          //  Thread.Sleep(30000);


            Datos miLoca = new Datos()
            {
                lat = (Double)_position.Latitude,
                lng = (Double)_position.Longitude,


            };

            envia.sendJson(miLoca);
          
            Console.WriteLine("envie un JSON");
            //Thread.Sleep(30000);
        }



    }
}