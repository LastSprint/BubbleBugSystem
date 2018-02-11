using System.Threading;
using Newtonsoft.Json;

namespace BubbleBugSystemController.Config {

    public class Config {

        private static Config _instance;
        private static object _lock = new object();

        internal static Config Instance {
            get {
                Monitor.Enter(_lock);
                if (_instance == null)
                {
                    _instance = Config.ReadConfig();
                }
                Monitor.Exit(_lock);
                return _instance;
            }
        }

        public string ServiceControllerBaseUri { get; set; }
        public string GetAllServicesRelativeUri { get; set; }

        private static Config ReadConfig() {
            var configString = System.Text.Encoding.Default.GetString(Resource.Config);
            return JsonConvert.DeserializeObject<Config>(configString);
        }
    }
}
