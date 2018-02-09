using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BubbleBugServerContainerController.Configuration;
using BubbleBugServerContainerController.Models;
using Microsoft.AspNetCore.Mvc;

namespace BubbleBugServerContainerController.Controllers {

    [Route("api/[controller]")]
    public class CreateNewServerController : Controller {

        private readonly Config _config;

        public CreateNewServerController() {
            this._config = Config.ReadConfig();
        }

        [HttpGet]
        public List<ApiServiceModel> AllServices() {
            
        }

    }
}
