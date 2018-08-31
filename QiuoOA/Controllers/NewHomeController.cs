using Cll;
using QiuoOA.Authorizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QiuoOA.Controllers
{
    [Authorizer]
    public class NewHomeController : BaseController
    {
        public ActionResult NewIndex()
        {
            ViewBag.islogin = IsUserLogin() ? 1 : 0;
            if (IsUserLogin())
            {
                Model.t_user model = GetUserInfo();
                if (model!=null)
                {
                    ViewBag.name = model.name;
                    ViewBag.employeename = model.employeename;
                }
            }
            return View();
        }

    }
}