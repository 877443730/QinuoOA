using NWJ.Cmn;
using qinuo.Cmn;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Cll
{
    public class BaseController : Controller
    {
        protected string msg = string.Empty;
        public BaseController()
        { }
        //protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        //{
        //    base.Initialize(requestContext);
        //    #region 验证登录==================================
        //    if (IsUserLogin())
        //    {
        //        Model.t_user model = GetUserInfo();
        //        ViewBag.UserName = model.username;
        //        ViewData["usermodel"] = model;
        //        ViewBag.islogin = 1;
        //        ViewBag.Navigation = Get_navigation();
        //        //获得最后登录日志
        //        DataTable dt = new Bll.user_login_log().GetList(2, "user_name='" + model.user_name + "'", "id desc").Tables[0];
        //        if (dt.Rows.Count == 2)
        //        {
        //            ViewBag.curr_login_ip = dt.Rows[0]["login_ip"].ToString();
        //            ViewBag.pre_login_ip = dt.Rows[1]["login_ip"].ToString();
        //            ViewBag.pre_login_time = dt.Rows[1]["login_time"].ToString();
        //        }
        //        else if (dt.Rows.Count == 1)
        //        {
        //            ViewBag.curr_login_ip = dt.Rows[0]["login_ip"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.islogin = 0;
        //        ViewBag.Navigation = Get_navigation();
        //        //ContentResult content = new ContentResult();
        //        //content.Content = string.Format("<script type='text/javascript'>alert('登陆后才可以查看该页面');window.parent.location.href='{0}';</script>", "/account/register?url=" + Request.Url);//?
        //        //System.Web.HttpContext.Current.Response.Write(content.Content);
        //    }
        //    #endregion
        //}
        #region 用户方法==========================================
        /// <summary>
        /// 判断用户是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsUserLogin()
        {
            //如果Session为Null
            if (System.Web.HttpContext.Current.Session[NKeys.SESSION_USER_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string username = Utils.GetCookie(NKeys.COOKIE_USER_NAME_REMEMBER, "qinuo");
                string password = Utils.GetCookie(NKeys.COOKIE_USER_PWD_REMEMBER, "qinuo");
                if (username != "" && password != "")
                {
                    Bll.t_user bll = new Bll.t_user();
                    Model.t_user model = new Model.t_user();
                    model = bll.GetModelpwd(username, password, false);
                    if (model != null)
                    {
                        System.Web.HttpContext.Current.Session[NKeys.SESSION_USER_INFO] = model;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得用户信息
        /// </summary>
        public Model.t_user GetUserInfo()
        {
            if (IsUserLogin())
            {
                Model.t_user model = System.Web.HttpContext.Current.Session[NKeys.SESSION_USER_INFO] as Model.t_user;
                if (model != null)
                {
                    //为了能查询到最新的用户信息，必须查询最新的用户资料
                    model = new Bll.t_user().GetModel(model.id);
                    return model;
                }
            }
            return null;
        }
        public int GetUserId()
        {
            if (IsUserLogin())
            {
                return GetUserInfo().id;
            }
            return 0;
        }
        public string GetUserName(int userid)
        {
            Model.t_user model = new Bll.t_user().GetModel(userid);
            string username = string.Empty;
            if (model != null)
            {
                if (string.IsNullOrEmpty(model.username))
                {
                    char[] arr = model.username.ToCharArray();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i == 3 || i == 4 || i == 5)
                            username += "*";
                        else
                            username += arr[i];
                    }
                    return username;
                }
                return model.employeename;
            }
            return "游客";
        }

        #endregion
    }
}
