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

        [HttpPost("GetUser")]
        public async Task<ActionResult<Users>> GetUser(Users u)
        {
            Users u1 = await this._ibus.GetUser(u);
            return new OkObjectResult(u1);
        }

        [HttpPost("CreateTicket")]
        public async Task<ActionResult<Users>> CreateTicket(Tickets t)
        {
            Tickets t1 = await this._ibus.CreateTicket(t);
            return new OkObjectResult(t1);
        }

        [HttpPut("UpdateTicket")]
        public async Task<ActionResult<Users>> UpdateTicket(Tickets t)
        {
            Tickets t1 = await this._ibus.UpdateTicket(t);
            return new OkObjectResult(t1);
        }

        [HttpGet("GetPendingTickets")]
        public async Task<List<Tickets>> GetPendingTickets()
        {
            List<Tickets> t1 = new List<Tickets> ();
            t1 = await this._ibus.GetPendingTickets();
            return t1;
        }

        [HttpPost("GetMyTickets/{UserID}")]
        public async Task<List<Tickets>> GetMyTickets(Tickets t)
        {
            List<Tickets> t1 = await this._ibus.GetMyTickets(t);
            return t1;
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<Users>> UpdateUser(Users u)
        {
            Users u1 = await this._ibus.UpdateUser(u);
            return new OkObjectResult(u1);
        }

    }
}