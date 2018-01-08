using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BubbleBugServerContainerController.Controllers {

    [Route("api/[controller]")]
    public class CreateNewServerController : Controller {

        public object CreateNewServer(string projectName) {
            var hash = projectName.GetHashCode();
            //TODO: - Make repository
        }
    }
}
