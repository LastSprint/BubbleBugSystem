using System;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BubbleBugServerContainerController.Configuration {

    /// <summary>
    /// Contains information for configuration module
    /// </summary>
    public class Config {

        private static Config _instance;
        private static object _lock = new object();

        internal static Config Instance {
            get {
                Monitor.Enter(_lock);
                if (_instance == null) {
                    _instance = Config.ReadConfig();
                }
                Monitor.Exit(_lock);
                return _instance;
            }
        }

        /// <summary>
        /// Path to root API folder (folder that contsins all generated API services)
        /// </summary>
        public string ServiceRootFolder { get; set; }

        /// <summary>
        /// Path to db file, that contains information about axisted services
        /// </summary>
        public string DbFilePath { get; set; }

        /// <summary>
        /// Start of port range
        /// </summary>
        public long StartPort { get; set; }

        /// <summary>
        /// End of port range
        /// </summary>
        public long EndPort { get; set; }

        public static Config ReadConfig() {
            var configString = System.Text.Encoding.Default.GetString(Resource.config);
            return JsonConvert.DeserializeObject<Config>(configString);
        }
    }
}
