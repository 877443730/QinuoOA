
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomerAttribute
{
    public class MVCHeaderAttrbute : ActionFilterAttribute
    {

        public MVCHeaderType mVCHeaderType { get; set; } = MVCHeaderType.IndexHeader;
        public MVCHeaderAttrbute(MVCHeaderType mVCHeaderType)
        {
            this.mVCHeaderType = mVCHeaderType;
        }

        //action执行之前先执行此方法  
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ((Controller)filterContext.Controller).ViewBag.HeaderType = this.mVCHeaderType;
        }

    }
    public enum MVCHeaderType
    {
        IndexHeader
    }
}
