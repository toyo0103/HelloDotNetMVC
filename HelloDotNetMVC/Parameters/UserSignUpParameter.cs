using FluentValidation.Attributes;
using HelloDotNetMVC.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloDotNetMVC.Parameters
{
    /// <summary>
    /// Parameter UserSignUp
    /// </summary>
    [Validator(typeof(UserSignUpParameterValidation))]
    public class UserSignUpParameter
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string  Account { get; set; }

        /// <summary>
        /// 密碼.
        /// </summary>
        public string Password { get; set; }
    }
}