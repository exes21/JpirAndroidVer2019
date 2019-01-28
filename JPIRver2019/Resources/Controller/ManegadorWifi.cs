using Android.Content;
using Android.Net.Wifi;
using System.Net;
using System.Net.NetworkInformation;

using System;
using System.Text;
using System.Net.Sockets;
using System.Linq;
using Android.Net;

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

        //funcion que me devuelve el SSID del router
        public string getSSID(Context context)
        {
            WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
            return wifiManager.ConnectionInfo.SSID;
        }

        public void getGateway(Context context)
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



    
