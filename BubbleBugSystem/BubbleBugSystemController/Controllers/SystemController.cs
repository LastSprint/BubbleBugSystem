using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BubbleBugSystemController.Controllers {
    [Route("api/[controller]")]
    public class SystemController : Controller {

        /// <summary>
        /// Запускает генерацию мокового сервера.
        /// </summary>
        /// <param name="pathToSpecification">Путь к файлу спецификации</param>
        /// <returns></returns>
        [HttpPost]
        public object StartGenerator(string pathToSpecification) {

            if (!System.IO.File.Exists(pathToSpecification)) {
                return new BadRequestResult();
            }

            return new CreatedResult(this.HttpContext.Connection.LocalIpAddress.ToString(), "Server was created");
        }
    }
}
