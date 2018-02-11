using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BubbleBugSharedModels;
using BubbleBugSystemController.Config;
using Newtonsoft.Json;

namespace BubbleBugSystemController.Services {

    public class ServiceControllerService {

        private readonly HttpClient _client;
        private readonly UriResolver _uriResolver;
        

        public ServiceControllerService(UriResolver resolver) {
            this._client = new HttpClient();
            this._uriResolver = resolver;
        }

        public async Task<IList<ServiceModel>> GetAllServices() {

            var response = await this._client.GetAsync(this._uriResolver.GetAllServicesUri);
            response.EnsureSuccessStatusCode();
            var contextString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IList<ServiceModel>>(contextString);
        }

    }
}
