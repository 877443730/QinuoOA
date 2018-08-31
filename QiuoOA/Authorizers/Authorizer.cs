using Cll;
using qinuo.Cmn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QiuoOA.Authorizers
{
    public class Authorizer: ActionFilterAttribute 
    {
        //验证登录
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            string url = System.Web.HttpContext.Current.Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session[NKeys.SESSION_USER_INFO] == null)
            {
                ContentResult content = new ContentResult();
                content.Content = string.Format("<script type='text/javascript'>window.parent.location.href='{0}';</script>", "/User/Login?url=" + filterContext.HttpContext.Request.Url);//?
                System.Web.HttpContext.Current.Response.Write(content.Content);
            }


        }
    }
}