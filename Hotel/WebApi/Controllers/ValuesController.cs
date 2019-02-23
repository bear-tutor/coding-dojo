using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private List<AccountInfo> account = new List<AccountInfo>();
        [HttpPost]
        public RegisterResult post([FromBody] AccountInfo value)
        {
            if (value.Username.Length >= 4 && value.Password.Length >= 4)
            {
                value.Id = Guid.NewGuid().ToString();
                account.Add(value);
                return new RegisterResult
                {
                    IsSuccess = true,
                    Message = "Login สำเร็จ"
                };
            }

            var a = account.Where(it => it.Username == value.Username).Any();
            if (a)
            {
                return new RegisterResult
                {
                    IsSuccess = true,
                    Message = "มี Username นี้แล้ว"
                };

            }

            else
            {
                return new RegisterResult
                {
                    IsSuccess = false,
                    Message = "LoginResult ไม่ถูกต้อง"
                };

            }
        }

        [HttpPost("Login")]
        public LoginResult login([FromBody]AccountInfo login)
        {
            var a = account.Where(it => it.Username == login.Username && it.Password == login.Password).Any();
            if (a)
            {
                return new LoginResult
                {
                    IsSuccess = true,
                    Message = "Login สำเร็จ"
                };
            }
            return new LoginResult
            {
                IsSuccess = false,
                Message = "Login ไม่ผ่าน"
            };
        }

        [HttpPost("sss")]
        public RegisterResult register([FromBody]AccountInfo value)
        {
            if(value.Username.Length >= 4 && value.Password.Length > 4)
            {
                value.Id = Guid.NewGuid().ToString();
                account.Add(value);

                return new RegisterResult
                {
                    IsSuccess = true,
                    Message = "Register เสร็จแล้ว"
                };

            }
            var a = account.Any(it => it.Username == value.Username);
            if(a)
            {
                return new RegisterResult
                {
                    IsSuccess = false,
                    Message = "มี Username แล้ว"
                };


            }
            return new RegisterResult
            {
                IsSuccess = false,
                Message = "Username หรือ password ต่ำกว่า 4 ตัวอักษร"
            };

        }

        [HttpPost("loin")]
        public LoginResult Llogin([FromBody]AccountInfo value)
        {
            var a = account.Any(it => it.Username == value.Username && it.Password == value.Password);
            return new LoginResult
            {
                IsSuccess = a,
                Message = a ? "Login สำเร็จ" : "Username หรือ Password ไม่ถูก"
            };
        }
        
    }
}
