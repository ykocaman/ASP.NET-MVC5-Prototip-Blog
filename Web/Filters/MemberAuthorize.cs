using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helpers;

namespace Web.Filters
{
    public class MemberAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (UserHelper.isMember() == true)
            {
                return true;
            }

            httpContext.Response.Redirect("/User/LoginForm");
            return false;
        }
    }
}