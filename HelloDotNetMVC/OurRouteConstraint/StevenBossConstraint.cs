using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace HelloDotNetMVC.OurRouteConstraint
{
    public class StevenBossConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //先確定Route中有我們設定的變數
            if (values.ContainsKey(parameterName))
            {
                //將變數的值拿出來,例如ID
                var ParameterValue = values[parameterName];

                if (ParameterValue != null)
                {
                    //如果ID轉成小寫後等於steven , 或是可以轉成數字
                    //就回傳True
                    int temp;
                    if (ParameterValue.ToString().ToLower() == "steven" ||
                       int.TryParse(ParameterValue.ToString(), out temp))
                    {
                        return true;
                    }
                }            
            }

            return false;
        }
    }
}