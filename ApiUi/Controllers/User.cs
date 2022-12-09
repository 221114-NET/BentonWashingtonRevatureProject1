using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLayer;
using BusinessLayer;
using System.Text.Json;

namespace ApiUi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User : ControllerBase
    {
        private readonly IBusinessLayerClass _ibus;



        public User(IBusinessLayerClass ibus)
        {
            this._ibus = ibus;
        }


        [HttpPost("CreateUsers")]
        public async Task<ActionResult<Users>> CreateUser(Users u)
        {
            Users u1 = await this._ibus.CreateUser(u);
            return new OkObjectResult(u1);
           


        }

    }
}