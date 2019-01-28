
using Newtonsoft.Json;
using System.Net;
using System.IO;
using JPIRver2019.Resources.Controller;
using System;

namespace JPIRver2019.Resources.Controller
{
    class EnviaJson
    {
       // private ArmaJson miJson;

        

        public void sendJson(Datos datos)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://jpir-web.herokuapp.com/recibe");

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
                    var result = streamReader.ReadToEnd();
                }

                
            }
            catch (Exception e)
            {

            }




        }
    }
}