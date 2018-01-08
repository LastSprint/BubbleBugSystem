namespace BubbleBugServerContainerController.Models {

    public struct ProjectModel {

        public string ProjectName { get; }
        public string Id { get; }
        public long Port { get; }

        public ProjectModel(string projectName, long port): this() {
            this.ProjectName = projectName;
            this.Id = projectName.GetHashCode().ToString();
            this.Port = port;
        }
    }
}
