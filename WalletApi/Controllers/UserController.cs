using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WalletApi.Models;

namespace WalletApi.Controllers
{
    [Route("api/user")]

    public class UserController : ControllerBase
    {
        private readonly UserContext _Context;
        public UserController(UserContext context, UserItems userItems)
        {
            _Context = context;
            if (_Context.UserItems.Count() == 0)
            {
                _Context.UserItems.Add(new UserItems {Id=userItems.Id, Name = userItems.Name, Familly=userItems.Familly, NationalCode=userItems.NationalCode, AccountNumber=userItems.AccountNumber,  
                AccountBalance =userItems.AccountBalance});
                _Context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<UserItems> GetAll()
        {
            return _Context.UserItems.ToList();
        }
        public IActionResult GetById(long id)
        {
            var item = _Context.UserItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        public IActionResult Create([FromBody] UserItems item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _Context.UserItems.Add(item);
            _Context.SaveChanges();
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UserItems item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
            var User = _Context.UserItems.FirstOrDefault(t => t.Id == id);
            if (User == null)
            {
                return NotFound();
            }
            User.IsComplete = item.IsComplete;
            User.Name = item.Name;
            User.Familly = item.Familly;
            User.NationalCode = item.NationalCode;
            User.AccountNumber = item.AccountNumber;
            User.AccountBalance = item.AccountBalance;
            return new NoContentResult();
        }
        public UserContext Get_Context()
        {
            return _Context;
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id, UserContext _Context)
        {
            var User = _Context.UserItems.FirstOrDefault(t => t.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            _Context.UserItems.Remove(User);
            _Context.SaveChanges();
            return new NoContentResult();
        }
    }
}
