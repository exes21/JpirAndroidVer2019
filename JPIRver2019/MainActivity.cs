using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android;
using Android.Content.PM;
using System;
using System.Threading;

using Plugin.Geolocator.Abstractions;
using JPIRver2019.Resources.controller;
using System.Net;
using Java.IO;
using Android.Util;

namespace JPIRver2019.Resources.Controller
{
    
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

   
    public class MainActivity : AppCompatActivity
    {
        System.Timers.Timer timer = new System.Timers.Timer();




        protected override void OnCreate(Bundle savedInstanceState)
        {
            //  mail = (EditText)FindViewById(Resource.Id.);
            


           


            // Toast.MakeText(ApplicationContext, "llame al servicio", ToastLength.Long).Show();
            base.OnCreate(savedInstanceState);

            if (CheckSelfPermission(Manifest.Permission.AccessCoarseLocation) != (int)Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
            }

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            Button button = this.FindViewById<Button>(Resource.Id.button_submit);
            button.Click += Button_click;
           // Toast.MakeText(ApplicationContext,"entrando a la funcion" , ToastLength.Long).Show();
           
            
        }

        private async void Button_click(object sender, EventArgs e)
        {
          
            //---------------------



            var url = this.FindViewById<EditText>(Resource.Id.url);
            Settings.url = url.Text;


            var mail = this.FindViewById<EditText>(Resource.Id.text_email);
            string email = mail.Text;
            if (email == "")
            {
                Toast.MakeText(ApplicationContext, "Debe introducir su correo electronico",
                    ToastLength.Long).Show(); 
            }
            else
            {
                Settings.email = email;
               // Toast.MakeText(ApplicationContext, Settings.email, ToastLength.Long).Show();
            }

            var pass = this.FindViewById<EditText>(Resource.Id.pass);
            string passwor = pass.Text;
            if (passwor == "")
            {
                Toast.MakeText(ApplicationContext, "Debe introducir su contraseña", ToastLength.Long).Show();
            }
            else
            {
                Settings.pass = passwor;
            }
            if(email != "" && passwor != "")
            {
                Toast.MakeText(ApplicationContext, "¡Conectando!", ToastLength.Long).Show();

                StartService(new Intent(this, typeof(services1)));
                // Activity.Finish;
            }
              

            // // Calculate calculate = new Calculate();
            //  //calculate.getJitter(ping.RTTdeMiPing);
            //escribir(email);
            //  leerFicheroMemoriaInterna();


            // bool y = await ManagerFicheros.IsFileExistAsync("prueba");

            // Toast.MakeText(ApplicationContext, y.ToString(), ToastLength.Long).Show();


            // x = await ManagerFicheros.ReadAllTextAsync("prueba");








            Thread hiloprincipal = new Thread(new ThreadStart(hilo2))
            {
                IsBackground = true
            };
            hiloprincipal.Start();
        }


        private void hilo2()
        {
            try
            {
                timer = new System.Timers.Timer();
                timer.Interval = 3000;
                timer.Elapsed += OnTimedEvent;
                timer.Enabled = true;
                timer.Start();
            }
            catch (Exception ex)
            {
               // Toast.MakeText(ApplicationContext, ex.Message, ToastLength.Long).Show();
            }

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {

            Thread hilo = new Thread(new ThreadStart(ejecutarhilo))
            {
                IsBackground = true
            };
            hilo.Start();
        }
        private async void ejecutarhilo()
        {
            RunOnUiThread(async () =>
            {

                //todo lo que ponga aquí se repite cada x (ahora 1) segundo

                //ManegadorWifi manejador = new ManegadorWifi();

                // Context context = this.ApplicationContext;




                // double x = manejador.getPing("8.8.8.8");



                //geo _geo = new geo();
                //Position _position = await _geo.GetPosition();
                //Toast.MakeText(ApplicationContext, _position.Latitude.ToString() + "," + _position.Longitude, ToastLength.Long).Show();


                //ArmaJson miJson = new ArmaJson();
                // await miJson.armarAsync();


              





            });

            
        }

       

    }
}