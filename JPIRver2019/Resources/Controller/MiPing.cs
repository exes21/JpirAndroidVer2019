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
    class MiPing
    {

        public List<long> RTTdeMiPing = new List<long>();
        public List<string> status = new List<string>();
        public List<string> Address = new List<string>();

        public double percent { get; set; }

        public void addRTT(long value)
        {
            RTTdeMiPing.Add(value);
        }

        public void addStatus(string value)
        {
            status.Add(value);
        }

        public void addAddress(string value)
        {
            Address.Add(value);
        }
    }
}