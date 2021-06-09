using Newtonsoft.Json;
using ServiceRequest.Helpers;
using ServiceRequest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceRequest.Services
{
    public class SrListService
    {
        #region Variables
        private HttpClientBase Client;
        #endregion Variables
        public SrListService()
        {
            Client = new HttpClientBase();
        }
        public async Task<List<RequestModel>>  GetSrList()
        {
            try
            {
                List<RequestModel> results;

                Uri serviceUri = new Uri(string.Format(AppSettings.SERVER_BASE + Helpers.ApiMethods.GetSrList));
                var response = await Client.GetAsync(serviceUri);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<List<RequestModel>>(responseString);
                    return results;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new Exception(HttpStatusMessage.NotFound);
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    throw new Exception(HttpStatusMessage.Forbidden);
                else if (response.StatusCode == System.Net.HttpStatusCode.MethodNotAllowed)
                    throw new Exception(HttpStatusMessage.MethodNotAllowed);
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    throw new Exception(HttpStatusMessage.InternalServerError);
                else
                    throw new Exception(HttpStatusMessage.Default);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
