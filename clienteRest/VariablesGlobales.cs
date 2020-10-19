using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace clienteRest
{
    public static class VariablesGlobales
    {
        public static HttpClient webClient = new HttpClient();
        static VariablesGlobales()
        {
            webClient.BaseAddress = new Uri("http://localhost:50072/api/");
            webClient.DefaultRequestHeaders.Clear();
            webClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}