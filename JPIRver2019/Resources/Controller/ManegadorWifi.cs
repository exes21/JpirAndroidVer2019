using Android.Content;
using Android.Net.Wifi;
using Android.Widget;
using Java.Interop;
using Java.IO;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Java.Lang;

using static Android.Resource;
using System.IO;

namespace JPIRver2019.Resources.Controller
{
    class ManegadorWifi

    {


            public int getLinkSpeed(Context context)
            {
                int linkSpeed = 0;
                WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
                WifiInfo wifiInfo = wifiManager.ConnectionInfo;
                if (wifiInfo != null)
                    linkSpeed = wifiInfo.LinkSpeed;

                return linkSpeed;
            }

            public int getSignLevel(Context context)
            {
                WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
                return wifiManager.ConnectionInfo.Rssi;
            }



        }



   




}



    
