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
    class Calculate
    {

        public long getLatency (List<long> RTT) {
            long count = 0;
            int i = 0; 

            foreach (long element in RTT)
            {
              //  Console.WriteLine("el RTT ES: {0} ", element);
                count= element + count;
                i++;
               

            }
            
            //Console.WriteLine("estoy adentro {0}", i + "vez/veces");
            count = count / (long) i;
           // Console.WriteLine("el Jitter es:" + count);
            return count;
        }



        public long getJitter(List<long> RTT)
        {
            
            long count = 0;
            long x = 0;
            int i = 1;


            foreach (long element in RTT)
            {
                
                x = difference(element, RTT[i]);
                
               // Console.WriteLine("Diferencia: {0} y {1}, la dif es: {2}", element, RTT[i], x);

                if(i < RTT.Count() - 1)
                {
                    i++;
                }

                count += x;

            }
           // Console.WriteLine("Jitter = {0}", count/4);

            return count /4;
        }

       private long difference(long x, long y)
        {
            long diff = 0 ;

            diff = x - y;

            if (diff < 0)
            {
                diff = diff * -1;
            }
                          
            return diff;
        }



    }
}