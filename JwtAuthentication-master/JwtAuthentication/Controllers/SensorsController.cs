using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;
using JwtAuthentication.Data;
using JwtAuthentication.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JwtAuthentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public SensorsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this._context = context;
            _userManager = userManager;
            _configuration = configuration;
        }


        /*// GET api/values/5
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        [HttpGet]
        public ActionResult<string> MySelf()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var myself = _userManager.GetUserAsync(this.User);
            return userId;
        }*/


        // GET api/sensors
        [HttpGet]
        public ActionResult<IEnumerable<SensorData>> Get()
        {
            return _context.SensorDatas;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<SensorData> Get(string id)
        {
            return _context.SensorDatas.FirstOrDefault(t => t.DeviceId == id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] SensorData value)
        {
            value.SensorId = Guid.NewGuid().ToString();

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var myself = await _userManager.GetUserAsync(this.User);

            _context.SensorDatas.Add(value);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] SensorData value)
        {
            var old = _context.SensorDatas.FirstOrDefault(t => t.DeviceId == id);
            _context.SensorDatas.Remove(old);
            _context.SensorDatas.Add(value);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var old = _context.SensorDatas.FirstOrDefault(t => t.DeviceId == id);
            _context.SensorDatas.Remove(old);
            _context.SaveChanges();
        }
    }
}
