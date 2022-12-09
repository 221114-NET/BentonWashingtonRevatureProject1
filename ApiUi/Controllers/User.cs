using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLayer;
using BusinessLayer;
using RepoLayer;
using System.Text.Json;

namespace ApiUi.Controllers
{
    [ApiController]
    [Route("[api/[controller]")]
    public class User : ControllerBase
    {
        private readonly IBusinessLayerClass _ibus;

        private readonly IRepositoryClass  _irep;

        public User(IBusinessLayerClass ibus, IRepositoryClass irep)
        {
            this._ibus = ibus;
            this._irep = irep;
        }


        [HttpPost("CreateUsers")]
        public async Task<ActionResult<Users>> CreateUser(Users u)
        {
            Users u1 = await this._irep.CreateUser(u);
            return new OkObjectResult(u1);
           


        }

    }
}