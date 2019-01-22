using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using JPIRver2019.Resources.controller;
using Plugin.Geolocator.Abstractions;


namespace JPIRver2019.Resources.Controller
{
    class ArmaJson
    {
        EnviaJson envia = new EnviaJson();
        public async System.Threading.Tasks.Task armarAsync()
        {
            geo _geo = new geo();
            Position _position = await _geo.GetPosition();
            Datos miLoca = new Datos()
            {
                lat = (Double)_position.Latitude,
                lng = (Double)_position.Longitude,


            };

            envia.sendJson(miLoca);
            
        }



    }
}