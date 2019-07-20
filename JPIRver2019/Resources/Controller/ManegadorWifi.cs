using Android.Content;
using Android.Net.Wifi;
using System.Net;
using System.Net.NetworkInformation;

using System;
using System.Text;
using System.Net.Sockets;
using System.Linq;
using Android.Net;
using Java.Lang;
using System.Collections.Generic;
using Java.Util;

namespace JPIRver2019.Resources.Controller
{
    class ManegadorWifi

    {

        //funcion que me devuelve la velocidad del enlace wifi
        public int getLinkSpeed(Context context)
        {
            int linkSpeed = 0;
            WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
            WifiInfo wifiInfo = wifiManager.ConnectionInfo;
            if (wifiInfo != null)
                linkSpeed = wifiInfo.LinkSpeed;

            return linkSpeed;
        }


        //funcion que me devuelve el nivel de la señal
        public int getSignLevel(Context context)
        {
            WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
            return wifiManager.ConnectionInfo.Rssi;
        }

        public string getMacAddreess(Context context)
        {
            try
            {
                System.Collections.IList all = Java.Util.Collections.List(Java.Net.NetworkInterface.NetworkInterfaces);
                foreach (Java.Net.NetworkInterface nif in all)
                {
                    if (nif.Name != "wlan0") continue;

                    byte[] macBytes = nif.GetHardwareAddress();
                    if (macBytes == null)
                    {
                        return "";
                    }

                    var res1 = new Java.Lang.StringBuilder();
                    foreach (byte b in macBytes)
                    {
                        res1.Append(Integer.ToHexString(b & 0xFF) + ":");
                    }

                    if (res1.Length() > 0)
                    {
                        res1.DeleteCharAt(res1.Length() - 1);
                    }
                    return res1.ToString();
                }
            }
            catch (Java.Lang.Exception ex)
            {
            }
            return "02:00:00:00:00:00";
        
    }

        //funcion que me devuelve el SSID del router
        public string getSSID(Context context)
        {
            WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
            return wifiManager.ConnectionInfo.SSID;
        }

        public string macDelRouter(Context context)
        {
            WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
            return wifiManager.ConnectionInfo.MacAddress;


        }
        public string prueba(Context context)
        {

            WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.NetworkStatsService);
            return wifiManager.ConnectionInfo.MacAddress;
        }


            public IPAddress getGateway(Context context)
        {
            //este meneo que esta conmentado me guta porque me da la mac address de la red

            ////  ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
            //  NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
            //  foreach (NetworkInterface Interface in Interfaces)
            //  {
            //      if (Interface.NetworkInterfaceType == NetworkInterfaceType.Loopback) continue;
            //      Console.WriteLine(Interface.Description);
            //      UnicastIPAddressInformationCollection UnicastIPInfoCol = Interface.GetIPProperties().UnicastAddresses;
            //      foreach (UnicastIPAddressInformation UnicatIPInfo in UnicastIPInfoCol)
            //      {
            //          Console.WriteLine("\tIP Address is {0}", UnicatIPInfo.Address);
            //          Console.WriteLine("\tSubnet Mask is {0}", UnicatIPInfo.IPv4Mask);
            //      }
            //  }







            /* NOTA: devuelve el default gate al reves, por obra del espiritu santo, pero se manda así y ya solte esto
             */

            WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
            string gateway = wifiManager.DhcpInfo.Gateway.ToString();
           
            IPAddress address = IPAddress.Parse(gateway);
            Console.WriteLine("\tIP AddrGateway es {0}",address ); 
            return address;
        }
    



        // un ejemplo de ping

        //------------------------------------
        public MiPing getPing()
        {
            MiPing UnPing = new MiPing();
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 119;
            string ip = "8.8.8.8";

            Ping ping = new Ping();

            int pingAmount = 4;
            int failed = 0;
            int completed = 0;

            for (int i = 0; i < pingAmount; i++)
            {
                PingReply reply = ping.Send(ip, timeout, buffer);
                if (reply.Status != IPStatus.Success)
                {
                    failed += 1;
                }
                else
                {
                    completed += 1;
                }

                UnPing.addRTT(reply.RoundtripTime);
                UnPing.addStatus(reply.Status.ToString());
                UnPing.addAddress(reply.Address.ToString());
            }

            UnPing.percent = (completed / pingAmount) * 100;

            return UnPing;
        }




    }



   




}



    
