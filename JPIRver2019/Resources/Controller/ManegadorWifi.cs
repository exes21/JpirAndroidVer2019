using Android.Widget;
using Java.Interop;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;


namespace JPIRver2019.Resources.Controller
{
    class ManegadorWifi

    {
        // args[0] can be an IPaddress or host name.
        public double getPing(String host)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            int pingAmount = 4;
            int failed = 0;
            int completed = 0;
            for (int i = 0; i < pingAmount; i++)
            {
                PingReply reply = pingSender.Send(host, timeout, buffer, options);
                if (reply.Status != IPStatus.Success)
                {
                    failed += 1;                                    
                }
                else
                {
                    completed += 1;
                }
                Console.WriteLine("Hola entre al for");
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
            Console.WriteLine("Completados: {0}", completed);
            Console.WriteLine("Fallados: {0}", failed);

            // Return the percentage
            double percent = (failed / pingAmount) * 100;
            return percent;
        }

    }
}
    
