using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helpers
{
    public static class UserHelper
    {
        public static User Current(){
            if (HttpContext.Current == null)
            {
                return null;
            }

            return (User)HttpContext.Current.Session["user"];
        }

        public static bool isAdmin()
        {
            return Current() != null && Current().UserType.Title == "Admin";
        }

        public static bool isMember()
        {
            return Current() != null;
        }

        public static bool isGuest()
        {
            return Current() == null;
        }
    }
}