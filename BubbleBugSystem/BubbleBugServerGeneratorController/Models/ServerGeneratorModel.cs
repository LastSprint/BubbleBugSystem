namespace BubbleBugServerGeneratorController.Models {

    public class ServerGeneratorModel {
        public bool NeedsToGenerateDefaultMocks { get; set; }
        public bool NeedsBuildAndDeploy { get; set; }
        public string PathToSpecificationFile { get; set; }

        public long Port { get; set; }
        public string RootFolder { get; set; }
    }
}
