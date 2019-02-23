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
        public RegisterResult Post([FromBody] AccountInfo account)
        {
            if (account.Username.Length < 4 || account.Password.Length < 4)
            {
                return new RegisterResult
                {
                    IsSuccess = false,
                    Message = "Username หรือ Password ต้องไม่ต่ำกว่า 4 ตัวอักษร"
                };
            }

            var isDupplicate = accounts.Any(it => it.Username == account.Username);
            if (isDupplicate)
            {
                return new RegisterResult
                {
                    IsSuccess = false,
                    Message = "Username มีอยู่ในระบบแล้ว"
                };
            }

            account.Id = Guid.NewGuid().ToString();
            accounts.Add(account);
            return new RegisterResult
            {
                IsSuccess = true,
                Message = "Register เสร็จสิ้น"
            };
        }

        // GET api/account/login
        [HttpGet]
        public IEnumerable<AccountInfo> Get()
        {
            return accounts;
        }

        // POST api/account/login
        [HttpPost("Login")]
        public LoginResult Login([FromBody] AccountInfo login)
        {
            //ดึงข้อมูล
            var AccountC = new AccountController();
            var Login = AccountC.Get();
            //หา-เทียบ any(true-flase)
            var LoginId = Login.Any(it => it.Username == login.Username && it.Password == login.Password);
            //ส่งค่ากลับ
            return new LoginResult
            {
                IsSuccess = LoginId,
                Message = LoginId ? "Login สำเร็จ" : "Username หรือ Password ไม่ถูก"
            };
        }

        //PUT api/account
        [HttpPut]
        public EditAccountResult EditAccount([FromBody] AccountInfo edit)
        {
            var EditAcc = accounts.FirstOrDefault(it => it.Id == edit.Id);
            if (EditAcc == null)
            {
                return new EditAccountResult
                {
                    IsSuccess = false,
                    Message = "แก้ไขข้อมูล ไม่สำเร็จ"
                };
            }

            EditAcc.Username = edit.Username;
            EditAcc.Password = edit.Password;
            return new EditAccountResult
            {
                IsSuccess = true,
                Message = "แก้ไขข้อมูล สำเร็จ",
            };
        }

        //HttpDelete api/account/{id}
        [HttpDelete("{id}")]
        public DeleteAccountResult DeleteAccount(string id)
        {
            var DeleteAcc = accounts.Where(it => it.Id == id).FirstOrDefault();
            accounts.Remove(DeleteAcc);

            if (DeleteAcc == null)
            {
                return new DeleteAccountResult
                {
                    IsSuccess = false,
                    Message = "ลบข้อมูล ไม่สำเร็จ"
                };
            }
            return new DeleteAccountResult
            {
                IsSuccess = true,
                Message = "ลบข้อมูล สำเร็จ",
            };
        }
    }
}
