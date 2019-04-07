
using Newtonsoft.Json;
using System.Net;
using System.IO;
using JPIRver2019.Resources.Controller;
using System;

namespace JPIRver2019.Resources.Controller
{
    class EnviaJson
    {
        public string sendJson(Datos datos)
        {
            
            var result = "";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Settings.url);
                //+ "/api/data/data_gather"
                httpWebRequest.ContentType = "application/json"; //tipo de archivo que contiene o MIME
                httpWebRequest.Method = "POST"; //METODO
                
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(datos);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                     result = streamReader.ReadToEnd();
                }

                if (result  != null)
                {
                    
                    Console.WriteLine("envie un json");
                }
                else
                {
                    Console.WriteLine("resultado es " + result.ToString());
                }


            }
            catch (Exception e)
            {

            }
            
            return result;

        }
    }
}