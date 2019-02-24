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
    public class AccountController : ControllerBase
    {
        private static List<AccountInfo> accounts = new List<AccountInfo>();

        // POST api/account
        [HttpPost]
        public RegisterResult Post([FromBody] AccountInfo req)
        {
            if (req.Username.Length < 4 || req.Password.Length < 4)
            {
                return new RegisterResult
                {
                    IsSuccess = false,
                    Message = "Username หรือ Password ต้องไม่ต่ำกว่า 4 ตัวอักษร"
                };
            }

            var isDupplicate = accounts
                .Where(it => it.Username == req.Username)
                .Any();
            if (isDupplicate)
            {
                return new RegisterResult
                {
                    IsSuccess = false,
                    Message = "Username มีอยู่ในระบบแล้ว"
                };
            }

            req.Id = Guid.NewGuid().ToString();
            accounts.Add(req);
            return new RegisterResult
            {
                IsSuccess = true,
                Message = "Register เสร็จสิ้น"
            };
        }

        // POST api/account/login
        [HttpPost("login")]
        public LoginResult Login([FromBody] AccountInfo req)
        {
            // var isFound = accounts
            //     .Where(it => it.Username == req.Username)
            //     .Where(it => it.Password == req.Password)
            //     .Any();

            var isFound = accounts
                .Any(it => it.Username == req.Username && it.Password == req.Password);

            return new LoginResult
            {
                IsSuccess = isFound,
                Message = isFound ? "Login สำเร็จ" : "Username หรือ Password ไม่ถูก"
            };
        }

        [HttpGet]
        public IEnumerable<GetAccountsResult> Get()
        {
            return accounts.Select(it => new GetAccountsResult
            {
                Id = it.Id,
                Username = it.Username,
            });
        }

        [HttpPut]
        public EditAccountResult Put([FromBody] AccountInfo value)
        {
            var areArgumentsValid = value != null
                && !string.IsNullOrWhiteSpace(value.Id)
                && !string.IsNullOrWhiteSpace(value.Username)
                && !string.IsNullOrWhiteSpace(value.Password)
                && value.Username.Length > 4
                && value.Password.Length > 4;

            if (!areArgumentsValid)
            {
                return new EditAccountResult
                {
                    IsSuccess = false,
                    Message = "Username หรือ Password ไม่ถูกต้อง"
                };
            }

            var selectedAccount = accounts.FirstOrDefault(it => it.Id == value.Id);
            if (selectedAccount == null)
            {
                return new EditAccountResult
                {
                    IsSuccess = false,
                    Message = "ไม่พบบัญชีผู้ใช้"
                };
            }

            var isChangedPasswordOnly = selectedAccount.Username == value.Username && selectedAccount.Password != value.Password;
            var isChangedUsernameOnly = selectedAccount.Password == value.Password && selectedAccount.Username != value.Username;

            if (isChangedPasswordOnly)
            {
                // Password only
                selectedAccount.Password = value.Password;
            }
            else if (isChangedUsernameOnly)
            {
                // Username
                selectedAccount.Username = value.Username;
            }
            else
            {
                // Username & Password
                selectedAccount.Username = value.Username;
                selectedAccount.Password = value.Password;
            }

            return new EditAccountResult
            {
                IsSuccess = true,
                Message = string.Empty
            };
        }

        [HttpDelete("{id}")]
        public DeleteAccountResult Delete(string id)
        {
            var selectedAccount = accounts.FirstOrDefault(it => it.Id == id);
            if (selectedAccount == null)
            {
                return new DeleteAccountResult
                {
                    IsSuccess = false,
                    Message = "ไม่พบบัญชีที่เลือก"
                };
            }

            accounts.Remove(selectedAccount);

            return new DeleteAccountResult
            {
                IsSuccess = true,
                Message = string.Empty
            };
        }
    }
}
