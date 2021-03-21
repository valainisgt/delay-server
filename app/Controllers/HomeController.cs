using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<object>> Get(int delay, string nonce)
        {
            if(delay < 0) {
                ModelState.AddModelError(nameof(delay), "Delay must be zero or greater");
                return this.BadRequest(ModelState);
            }
            await Task.Delay(delay).ConfigureAwait(false);
            return new {
                nonce = nonce,
                delay = delay
            };
        }
    }
}
