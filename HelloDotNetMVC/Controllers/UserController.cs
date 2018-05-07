using HelloDotNetMVC.Parameters;
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
        public ActionResult SignUp(UserSignUpParameter parameter)
        {
            if (!ModelState.IsValid)
            {
                //IsValida為False時，表示驗證參數不過
                //取出第一筆錯誤訊息回傳
                var Error = ModelState.Values.SelectMany(x => x.Errors).First();
                TempData["Message"] = Error.ErrorMessage;
                return RedirectToAction("signup", "user");
            }

            //這邊沒有搬到FluentValidation去驗證的原因是
            //使用者存在與否比較屬於服務層的事情，通常需要讀取資料庫才能判斷
            //開發上習慣盡量讓驗證參數越乾淨簡單越好，而不是在裡面呼叫很多外部服務(例如資料庫)後做驗證
            //這會讓職責過於複雜
            if (parameter.Account != "steven@mymail.com")
            {
                TempData["Message"] = "註冊成功!!";
                //註冊成功,導到首頁 
                return RedirectToAction("index", "home");

            }
            else
            {
                TempData["Message"] = "帳號已經存在";
                return RedirectToAction("signup", "user");
            }
        }
    }
}