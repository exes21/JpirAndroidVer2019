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
                count= element + count;
                i++;
            }
       
            count = count / (long) i;

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

                if(i < RTT.Count() - 1)
                {
                    i++;
                }

                count += x;

            }

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