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
using Newtonsoft.Json;

namespace JPIRver2019.Resources.Controller
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]


    public class MainStatus : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //  mail = (EditText)FindViewById(Resource.Id.);

            // Toast.MakeText(ApplicationContext, "llame al servicio", ToastLength.Long).Show();
            base.OnCreate(savedInstanceState);

            // 
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.status_layout);

            //Button button = this.FindViewById<Button>(Resource.Id.button_atras);
            //button.Click += Button_click;

            
            TextView user = this.FindViewById<TextView>(Resource.Id.usuarioNombre);
            user.Text = Settings.email;

            TextView estado = this.FindViewById<TextView>(Resource.Id.estado);
            estado.Text = Settings.estado;


            System.Timers.Timer timer = new System.Timers.Timer();
            StartService(new Intent(this, typeof(services1)));
            //  Toast.MakeText(ApplicationContext, "llame al servicio", ToastLength.Long).Show();
        }

        //private async void Button_click(object sender, EventArgs e)
        //{
        //}

    }
}