using FluentValidation.Attributes;
using HelloDotNetMVC.Validators;
using HelloDotNetMVC.Validators.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloDotNetMVC.Parameters
{
    /// <summary>
    /// Parameter UserSignUp
    /// </summary>
    public class UserSignUpParameter
    {
        
        /// <summary>
        /// 帳號
        /// </summary>
        [Required(ErrorMessage = "{0}為必填欄位")]
        [MouseCharacters(ErrorMessage ="{0}必須包含@字元")]
        public string Account { get; set; }

        /// <summary>
        /// 密碼.
        /// </summary>
        [Required(ErrorMessage = "{0}為必填欄位")]
        [StringLength(6, ErrorMessage = "{0}不得低於{1}個字元")]
        public string Password { get; set; }
    }
}