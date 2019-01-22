using Android.Content;
using Android.Net.Wifi;
using System.Net;
using System.Net.NetworkInformation;

using System;
using System.Text;
using System.Net.Sockets;

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

        public string getSSID(Context context)
        {
            WifiManager wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
            return wifiManager.ConnectionInfo.SSID;
        }

      


        //------------------------------------
        //public double getPing(string host)
        //{
        //    Ping pingSender = new Ping();
        //    PingOptions options = new PingOptions();
        //    options.Ttl = 119;
        //   // options.DontFragment = false;

        //    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        //    byte[] buffer = Encoding.ASCII.GetBytes(data);
        //    int timeout = 120;

        //    int pingAmount = 4;
        //    int failed = 0;
        //    int completed = 0;



        //    for (int i = 0; i < pingAmount; i++)
        //    {
        //        PingReply reply = pingSender.Send(host, timeout, buffer, options);
        //        if (reply.Status != IPStatus.Success)
        //        {
        //            failed += 1;
        //        }
        //        else
        //        {
        //            completed += 1;
        //        }
        //        Console.WriteLine("Hola entre al for");
        //        Console.WriteLine("Address: {0}", reply.Address.ToString());
        //        Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
        //        Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
        //        Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
        //        Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
        //    }
        //    Console.WriteLine("Completados: {0}", completed);
        //    Console.WriteLine("Fallados: {0}", failed);


        //    double percent = (failed / pingAmount) * 100;

        //   // string x = reply.RoundtripTime.ToString;

        //    return percent;


        //Runtime r = Runtime.GetRuntime();
        //System.Diagnostics.Process p = r.Exec(string.Format("ping -c {0} {1}", PingCount, PingHost));
        //p.WaitForExit();
        //int exit = p.ExitValue();





        //  }

        public void GetPing()
        {
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            string ip = "8.8.8.8";
            Ping ping = new Ping();
            for(int i = 0; i < 4; i++){
                PingReply pr = ping.Send(ip, timeout, buffer);
                Console.WriteLine("Respuesta desde {0}: bytes:{1} tiempo={2} {3})",
                    pr.Address, pr.Buffer.Length, pr.RoundtripTime,
                    pr.Status.ToString());
            }
           // Console.ReadLine();

       
        }





        }



   




}



    
