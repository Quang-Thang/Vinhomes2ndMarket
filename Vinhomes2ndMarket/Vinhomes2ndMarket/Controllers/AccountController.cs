using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Numerics;
using System.Reflection;
using Vinhomes2ndMarket.Models;


namespace Vinhomes2ndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Account> GetAllAccount()
        {
            return new List<Account>(){
                new Account
                {
                    AccountId = new Guid(),
                    BuildingId = 2,
                    Username = "Test",
                    RoleId = 1,
                    Gender = true
                },
                new Account
                {
                    AccountId = new Guid(),
                    BuildingId = 1,
                    Username = "Test2",
                    RoleId = 2,
                    Gender = false
                }
            };
        }
    }
}
