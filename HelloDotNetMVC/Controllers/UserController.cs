using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloDotNetMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            //回傳註冊頁
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string account, string password)
        {
            bool Result = false;
            //帳號密碼都不能為空值
            if (!string.IsNullOrWhiteSpace(account) &&
                !string.IsNullOrWhiteSpace(password))
            {
                //帳號必須要有@字元
                //密碼必須大於六個字元
                if (account.Contains("@") && password.Length > 6)
                {
                    //我們判斷是否有註冊過的帳號,因為還沒有連結資料庫
                    //所以先假定steven@mymail.com被註冊過
                    if (account != "steven@mymail.com")
                    {
                        TempData["Message"] = "註冊成功!!";
                        Result = true;
                    }
                    else
                    {
                        TempData["Message"] = "帳號已經存在";
                    }
                }
                else
                {
                    TempData["Message"] = "帳號密碼不符合格式";
                }
            }
            else
            {
                TempData["Message"] = "帳號密碼不能為空值";
            }

            if (Result)
            {
                //註冊成功,導到首頁 
                return RedirectToAction("index", "home");
            }
            else
            {
                return RedirectToAction("signup", "user");
            }
        }
    }
}