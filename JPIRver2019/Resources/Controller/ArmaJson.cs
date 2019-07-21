using System;
using System.Net;
using System.Threading;
using System.Timers;
using Android.Content;
using Android.Widget;
using Java.Util;
using JPIRver2019.Resources.controller;
using Plugin.Geolocator.Abstractions;


namespace JPIRver2019.Resources.Controller
{
    class ArmaJson
    {
        EnviaJson envia = new EnviaJson();
        ManegadorWifi manejador = new ManegadorWifi();
        Calculate calculate = new Calculate();
        

        public async System.Threading.Tasks.Task  armarAsync(int uno, int dos, string tres, 
            string cuatro, string MacAddress1, string macRouter)
        {
            
            geo _geo = new geo(); 
            Position _position = await _geo.GetPosition();
            MiPing iping = manejador.getPing();
            
            Datos datos = new Datos()
            {
                lat = (Double)_position.Latitude,
                lng = (Double)_position.Longitude,
                RTT = iping.RTTdeMiPing,
                status = iping.status,
                address = iping.Address,
                jitter = calculate.getJitter(iping.RTTdeMiPing),
                lantency = calculate.getLatency(iping.RTTdeMiPing),
                LinkSpeed = uno,
                SignLevel = dos,
                ssid = tres,
                DefaultGate = cuatro,
                MacAddress = MacAddress1,
                mail = Settings.email,
                pass = Settings.pass,
                MacDelRouter = macRouter,
            };


           string x = envia.sendJson(datos);
           changer changer = new changer();
           changer.changerStatus(x);
        }



    }
}