using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBMS.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MBMS.Controllers
{
    [Route("api/users")]
    public class UserAPIController : Controller
    {
        DataAccess dataAccess = new DataAccess();
        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return dataAccess.GetUsers();
        }

        // GET api/values/5
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var user = dataAccess.GetUser(new ObjectId(id));
            if (user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            //user.ID = ObjectId.GenerateNewId();
            dataAccess.CreateUser(user);
            return new OkObjectResult(user);
        }

        // PUT api/values/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]User u)
        {
            var objId = new ObjectId(id);
            var user = dataAccess.GetUser(objId);

            if (user == null)
            {
                return NotFound();
            }

            dataAccess.UpdateUser(objId, u);
            return new OkResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = dataAccess.GetUser(new ObjectId(id));
            if (user == null)
            {
                return NotFound();
            }

            dataAccess.RemoveUser(new ObjectId(id));
            return new OkResult();
        }
    }
}
