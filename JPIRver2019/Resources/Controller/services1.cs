using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using JPIRver2019.Resources.Controller;
using Plugin.Geolocator.Abstractions;
using Newtonsoft.Json;
using System.Net;
using System.IO;


namespace JPIRver2019.Resources.Controller

{
    [Service]
public class services1 : Service
{
       
        static readonly string TAG = typeof(services1).FullName;
        System.Timers.Timer timer = new System.Timers.Timer();
        public IBinder Binder { get; private set; }
    public override void OnCreate()
    {
        // This method is optional to implement
        base.OnCreate();

        Thread hiloprincipal = new Thread(new ThreadStart(hilo2))
        {
            IsBackground = true
        };
        hiloprincipal.Start();

           




        }

    public override IBinder OnBind(Intent intent)
    {
        // This method must always be implemented
        Log.Debug(TAG, "OnBind");
        return this.Binder;
    }

    public override bool OnUnbind(Intent intent)
    {
        // This method is optional to implement
        Log.Debug(TAG, "esto estara funciona");
        return base.OnUnbind(intent);
    }

    public override void OnDestroy()
    {
        // This method is optional to implement
        Log.Debug(TAG, "OnDestroy");
        Binder = null;
        base.OnDestroy();
    }


        private void hilo2()
        {
            Console.WriteLine("estoy en el SERVICIo");
      
             try
            {
                timer = new System.Timers.Timer();
                timer.Interval = 2000;
                timer.Elapsed += OnTimedEvent;
                timer.Enabled = true;
                timer.Start();
            }
            catch (Exception ex)
            {
                Toast.MakeText(ApplicationContext, ex.Message, ToastLength.Long).Show();
            }

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {


            




            Thread hilo = new Thread(new ThreadStart(ejecutarhilo))
            {
                IsBackground = true

            };
            
            hilo.Start();


            // hilo.Join();
            //    Thread.Sleep(60000);

            //hilo.Join();


        }
        private async void ejecutarhilo()
        {
            ArmaJson miJson = new ArmaJson();
            await miJson.armarAsync();

            Console.WriteLine("llamo a medicion");


           
            // Thread.Sleep(60000);

            await miJson.armarAsync();

            // EnviaJson envia = new EnviaJson();
            //envia.sendJson(miJson);

            // Console.WriteLine("estoy en el SERVICIO");
            // await _ServiceData.AddTodoItemAsync(_TodoItem);



            //ManegadorWifi manejador = new ManegadorWifi();

            //Context context = this.ApplicationContext;

            //int x = manejador.getSignLevel(context);

           





        }


    }
}