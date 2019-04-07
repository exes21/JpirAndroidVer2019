using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JPIRver2019.Resources.Controller
{
    class Datos
    {

        public double lat { get; set; } //latitud
        public double lng { get; set; } //longitud

        //public MiPing xPing { get; set; }
        public List<long> RTT { get; set; }

        public List<string> status { get; set; }

        public List<string> address { get; set; }

        public long lantency { get; set; }

        public long jitter { get; set; }

       public string MacDelRouter { get; set; }
        
        public int LinkSpeed { get; set; }

        public int SignLevel { get; set; }

        public string mail { get; set; }

        public string ssid { get; set; }

        public string DefaultGate { get; set; }

        public string MacAddress { get; set; }

        public string pass { get; set; }

    }


}
