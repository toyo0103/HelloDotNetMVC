using FluentValidation;
using HelloDotNetMVC.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloDotNetMVC.Validators
{
    /// <summary>
    /// Validation UserSignUpParameter
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{HelloDotNetMVC.Parameters.UserSignUpParameter}" />
    public class UserSignUpParameterValidation:AbstractValidator<UserSignUpParameter>
    {
        public UserSignUpParameterValidation()
        {
            //AbstractValidator為FluentValidation提供的抽象類別
            //目的是讓使用者可以透過繼承這個抽象類別後，實作自己的驗證邏輯
            //而泛型T， AbstractValidator<T> ，則帶入你想驗證的類別
            //所以這邊帶入UserSignUpParameter，這個我們剛剛製作的Class

            //Account
            RuleFor(x => x.Account)
            .NotEmpty()
            .WithMessage("帳號不能為Empty")
            .NotNull()
            .WithMessage("帳號不能為Null")
            .Must(IncludeAccountKeyword)
            .WithMessage("帳號不符合格式");

            //Password
            RuleFor(x=>x.Password)
            .NotEmpty()
            .WithMessage("密碼不能為Empty")
            .NotNull()
            .WithMessage("密碼不能為Null")
            .MinimumLength(7)
            .WithMessage("密碼必須大於6個字元");
        }

        /// <summary>
        /// Accounts 必須包含@.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        private bool IncludeAccountKeyword(string account)
        {
            if (!string.IsNullOrWhiteSpace(account))
            {
                return account.Contains("@");
            }

            return false;
        }
    }
}