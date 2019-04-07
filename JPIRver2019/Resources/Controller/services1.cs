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
        
        ArmaJson miJson = new ArmaJson();
        EnviaJson enviaJson = new EnviaJson();
        

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

            hiloprincipal.Join();



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


        private async void hilo2()
        {
            //Context context = this.ApplicationContext;
            //ManegadorWifi manejador = new ManegadorWifi();
            //int uno = manejador.getLinkSpeed(context);
            //int dos = manejador.getSignLevel(context);
            //string tres = manejador.getSSID(context);
            //string cuatro = manejador.getGateway(context).ToString();

            //miJson.armarAsync(uno, dos, tres, cuatro);
            try
            {
                Context context = this.ApplicationContext;
                ManegadorWifi manejador = new ManegadorWifi();
                int uno = manejador.getLinkSpeed(context);
                int dos = manejador.getSignLevel(context);
                string tres = manejador.getSSID(context);
                string cuatro = manejador.getGateway(context).ToString();
                string MacAddress1 = manejador.getMacAddreess(context);
                string macRouter = manejador.macDelRouter(context);

                miJson.armarAsync(uno, dos, tres, cuatro, MacAddress1, macRouter);



                timer = new System.Timers.Timer();
                timer.Interval = 60000; //mas o menos cada 1 minutos se actuliza
                timer.Elapsed += OnTimedEventAsync;
                timer.Enabled = true;
                timer.Start();
                
            }
            catch (Exception ex)
            {
                Toast.MakeText(ApplicationContext, ex.Message, ToastLength.Long).Show();
            }

        }

        private async void OnTimedEventAsync(Object source, System.Timers.ElapsedEventArgs e)
        {
            Context context = this.ApplicationContext;
            ManegadorWifi manejador = new ManegadorWifi();
            int uno = manejador.getLinkSpeed(context);
            int dos = manejador.getSignLevel(context);
           string tres = manejador.getSSID(context);
            string cuatro = manejador.getGateway(context).ToString();
            string MacAddress1 = manejador.getMacAddreess(context);
            string macRouter = manejador.macDelRouter(context);

            miJson.armarAsync(uno, dos, tres, cuatro, MacAddress1, macRouter);
        }
        private async void ejecutarhilo()
        {


           


            // Thread.Sleep(60000);

            //  await miJson.armarAsync();

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