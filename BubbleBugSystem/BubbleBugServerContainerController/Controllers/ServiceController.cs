using System.Collections.Generic;
using BubbleBugServiceController.Configuration;
using BubbleBugServiceController.DbServices;
using BubbleBugSharedModels;
using Microsoft.AspNetCore.Mvc;

namespace BubbleBugServiceController.Controllers {

    [Route("api/[controller]")]
    public class ServiceController : Controller {

        private readonly Config _config;
        private readonly IRepository<ServiceModel> _repository;

        public ServiceController() {
            this._config = Config.Instance;
            this._repository = new ServiceRepository();
        }

        [HttpGet]
        public IList<ServiceModel> GetAllServices() {
            return this._repository.ReadAll();
        }

    }
}
