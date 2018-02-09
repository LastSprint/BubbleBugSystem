using System;

namespace BubbleBugServerContainerController.Models {

    public class ApiServiceModel {

        public string ProjectName { get; }
        public string Id { get; }
        public long Port { get; set; }

        public ApiServiceModel(string projectName, long port) {
            this.ProjectName = projectName;
            this.Id = projectName.GetHashCode().ToString();
            this.Port = port;
        }
    }
}
