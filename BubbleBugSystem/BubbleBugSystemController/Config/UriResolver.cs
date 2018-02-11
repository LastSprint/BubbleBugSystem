namespace BubbleBugSystemController.Config {

    public class UriResolver {

        private readonly Config _config;

        public string BaseServiceControllerUri => this._config.ServiceControllerBaseUri;

        public string GetAllServicesUri => this.BaseServiceControllerUri + this._config.GetAllServicesRelativeUri;

        public UriResolver(Config config) {
            this._config = config;
        }

    }
}
