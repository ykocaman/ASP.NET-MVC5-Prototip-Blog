using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    [Filters.AdminAuthorize]
    public class BaseController : Controller
    {
    
    }
}