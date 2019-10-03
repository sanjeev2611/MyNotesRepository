namespace NotesClient.Helpers
{
    using System;
    using System.Configuration;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;

    /// <summary>
    /// Class to setup HttpClient which will be used for calling APIs
    /// </summary>
    public static class GlobalVariables
    {
        public static HttpClient webApiClient = new HttpClient();

        /// <summary>
        /// Constructor to setup basic Http Request
        /// </summary>
        static GlobalVariables()
        {
            webApiClient.BaseAddress = new Uri("https://localhost:44387/");
            webApiClient.DefaultRequestHeaders.Clear();            
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Required for local debugging
            ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
        }
    }
}