namespace BubbleBugSharedModels {

    public class ServiceModel {

        public string Name { get; set; }
        public string PathToPoject { get; set; }
        public long Port { get; set; }
        public long Id => this.Name.GetHashCode() ^ this.Port.GetHashCode();
        public ServiceMetaData MetaData { get; set; }

        public ServiceModel(string name, long port, string pathToProject) {
            this.Name = name;
            this.Port = port;
            this.PathToPoject = pathToProject;
        }
    }
}
