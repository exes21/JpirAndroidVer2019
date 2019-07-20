
using Newtonsoft.Json;
using System.Net;
using System.IO;
using JPIRver2019.Resources.Controller;
using System;
using Android.Widget;

namespace JPIRver2019.Resources.Controller
{
    class EnviaJson
    {
        public object DependencyService { get; private set; }

        public string sendJson(Datos datos)
        {
            changer status = new changer();
            var result = "";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.0.99" + "/api/data/data_gather");//Settings.url + " /api/data/data_gather");
                //
                httpWebRequest.ContentType = "application/json"; //tipo de archivo que contiene o MIME
                httpWebRequest.Method = "POST"; //METODO
                
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(datos);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse myResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }

                status.changerStatus(myResponse.StatusDescription);
                myResponse.Close();

                if (result  != null)
                {
                    
                    Console.WriteLine("envie un json");
                    Console.WriteLine("resultado es " + result.ToString());
                }
                else
                {
                    Console.WriteLine("resultado es " + result.ToString());
                }


            }
            catch (WebException x)
            {
                status.changerStatus(x.Status.ToString());

                //string responcode;
                //using (var r = new StreamReader(x.Response.GetResponseStream()))
                //{
                //    responcode = r.ReadToEnd();
                //}
            }
           
            
                            
            
            return result;

        }
    }
}