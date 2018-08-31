using Cll;
using System.Web.Mvc;
using NWJ.Cmn;
using qinuo.Cmn;
using System;
using QiuoOA.Authorizers;

namespace QiuoOA.Controllers
{
    public class UserController : BaseController
    {
        Bll.t_user userbll = new Bll.t_user();
        Bll.t_role rolebll = new Bll.t_role();
        Bll.user_role user_rolebll = new Bll.user_role();
        Bll.t_permission t_permissionbll = new Bll.t_permission();
        Bll.role_permission role_permissionbll = new Bll.role_permission();
        [Authorizer]
        public ActionResult UserList()
        {
            Model.t_user model = GetUserInfo();
            if (model!=null)
            {
                ViewBag.name = model.name;
                ViewBag.employeename = model.employeename;
            }

            ViewData["userlist"] = userbll.GetModelLists("1=1");
            return View();
        }
        [Authorizer]
        public ActionResult AddUser()
        {
            Bll.t_role bllrole = new Bll.t_role();
            Model.t_user model = GetUserInfo();
            ViewData["zhiwu"] = bllrole.GetModelList("1=1");
            if (model != null)
            {
                ViewBag.employeename = model.employeename;
            }
            return View();
        }
        [HttpPost]
        public JsonResult AddUserCons(string username, string name, string pwd, string zhiwu, string jurisdiction)
        {
            string msg = AddUserCon(username, name, pwd, zhiwu, jurisdiction);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string AddUserCon(string username, string name, string pwd, string zhiwu, string jurisdiction)
        {
            Model.t_user model = new Model.t_user();
            Model.t_role model1 = new Model.t_role();
            Model.user_role model2 = new Model.user_role();
            Model.t_permission model3 = new Model.t_permission();
            Model.role_permission model4 = new Model.role_permission();
            if (username==null && name==null && pwd == null && zhiwu == null && jurisdiction == null)
            {
                return "{\"status\": 0,\"msg\":\"添加失败！\"}";
            }

            if (username != null && name != null && pwd != null)
            {
                model.username = username;
                model.employeename = name;
                model.pwd = DESEncrypt.Encrypt(pwd);
                model.adddate = (DateTime.Now).ToString();
                userbll.Add(model);
            }
            if (jurisdiction != null)
            {
                model3.pename = jurisdiction;
                model3.adddate = (DateTime.Now).ToString();
                t_permissionbll.Add(model3);
            }

            Model.t_user tmodel = new Model.t_user();
            tmodel = userbll.GetModels();

            Model.t_role tmodel1 = new Model.t_role();
            tmodel1 = rolebll.GetModelss(zhiwu);

            Model.t_permission tmodel3 = new Model.t_permission();
            tmodel3 = t_permissionbll.GetModels();
            if (tmodel != null)
            {
                //用户ID
                model2.userid = tmodel.id;
                //角色id
                model2.roleid = tmodel1.id;
                user_rolebll.Add(model2);
            }

            if (tmodel3 != null)
            {
                model4.permissionid = tmodel3.id;
                model4.roleid = tmodel1.id;
                role_permissionbll.Add(model4);
            }
 
            return "{\"status\": 1,\"msg\":\"添加成功！\"}";
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SignIn(string username, string password)
        {
            string msg = Loginpwd(username, password);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        private string Loginpwd(string username, string password)
        {
            string remember = NRequest.GetFormString("chkRemember");
            Model.t_user model = new Bll.t_user().GetModelpwd(username, password, true);
            if (model == null)
            {
                return "{\"status\": 0,\"msg\": \"错误提示：用户名或密码错误，请重试！\"}";
            }
            //读取session验证登陆
            System.Web.HttpContext.Current.Session[NKeys.SESSION_USER_INFO] = model;
            System.Web.HttpContext.Current.Session.Timeout = 45;
            if (!string.IsNullOrEmpty(remember))
            {
                Utils.WriteCookie(NKeys.COOKIE_USER_NAME_REMEMBER, "qinuo", model.username, 43200);
                Utils.WriteCookie(NKeys.COOKIE_USER_PWD_REMEMBER, "qinuo", model.pwd, 43200);
            }
            else
            {
                //防止Session提前过期
                Utils.WriteCookie(NKeys.COOKIE_USER_NAME_REMEMBER, "qinuo", model.username);
                Utils.WriteCookie(NKeys.COOKIE_USER_PWD_REMEMBER, "qinuo", model.pwd);
            }
            return "{\"status\": 1,\"msg\":\"登录成功！\"}";
        }

        /// <summary>
        /// 检查登录状态
        /// </summary>
        /// <returns></returns>
        public string CheckLoginStatus()
        {
            Model.t_user model = new Model.t_user();
            if (System.Web.HttpContext.Current.Session[NKeys.SESSION_USER_INFO] != null)
                model = (Model.t_user)System.Web.HttpContext.Current.Session[NKeys.SESSION_USER_INFO];
            string session = model.username;
            if (!string.IsNullOrEmpty(session))
                return session;
            else
                return "null";
        }
        public ActionResult Updatepwd()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Updatepwds(string updatepwd, string updatepwd2,string username)
        {
            string msg = Updatepwdss(updatepwd, updatepwd2, username);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string Updatepwdss(string updatepwd, string updatepwd2,string username) {
            Model.t_user model= userbll.GetUpdatepwd(username);
            if (model==null)
            {
                return "{\"status\": 2,\"msg\": \"错误提示：没有此账号，请重试！\"}";
            }

            if (updatepwd != updatepwd2)
            {
                return "{\"status\": 0,\"msg\": \"错误提示：2次密码不一致，请重试！\"}";
            }
            if (model!=null)
            {
                model.pwd= DESEncrypt.Encrypt(updatepwd2);
                userbll.Update(model);
            }
            return "{\"status\": 1,\"msg\": \"修改成功！\"}";

        }
        [Authorizer]
        public ActionResult UpdateUser(int id) {
            Bll.t_role bllrole = new Bll.t_role();
         
            Model.t_user model = userbll.GetModel(id);
            ViewBag.username = model.username; //账号
            ViewBag.employeename = model.employeename;//姓名
            ViewBag.pwd = model.pwd;
            if (model != null)
            {
                Model.user_role urmodel = user_rolebll.GetModels(model.id);
                Model.t_role rolemodel = rolebll.GetModel(urmodel.roleid);
                ViewBag.zhiwu = rolemodel.name;
                if (rolemodel != null)
                {
                    Model.role_permission rolepemodel = role_permissionbll.GetModels(rolemodel.id);
                    Model.t_permission permmodel = t_permissionbll.GetModel(rolepemodel.permissionid);
                    ViewBag.pername = permmodel.pename;
                }
                ViewData["zhiwu1"] = bllrole.GetModelList("1=1");
            }
            return View();
        }

        [HttpPost]
        public JsonResult UpdateUsers(string username, string name, string pwd, string zhiwu, string jurisdiction)
        {
            string msg = UpdateUserss(username, name, pwd, zhiwu, jurisdiction);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string UpdateUserss(string username, string name, string pwd, string zhiwu, string jurisdiction)
        {
            if (username == null && name == null && pwd == null && zhiwu == null && jurisdiction == null)
            {
                return "{\"status\": 0,\"msg\":\"修改失败！\"}";
            }

            Model.t_user model=userbll.GetModelss(username);
            if (model!=null)
            {
                model.username = username;
                model.employeename = name;
                model.pwd = DESEncrypt.Encrypt(pwd);
                userbll.Update(model);
            }
            Model.user_role urmodel = user_rolebll.GetModels(model.id);
            Model.t_role rolemodel = rolebll.GetModelss(zhiwu);
            if (rolemodel!=null)
            {
                urmodel.roleid = rolemodel.id;
                user_rolebll.Update(urmodel);
            }
            //if (rolemodel!=null)
            //{
            //    rolemodel.name = zhiwu;
            //    rolebll.Update(rolemodel);
            //}
            Model.role_permission rolepemodel = role_permissionbll.GetModels(rolemodel.id);
            Model.t_permission permmodel = t_permissionbll.GetModel(rolepemodel.permissionid);
            if (permmodel!=null)
            {
                permmodel.pename = jurisdiction;
                t_permissionbll.Update(permmodel);
            }
            return "{\"status\": 1,\"msg\":\"修改成功！\"}";
        }

        public bool DeleteUser(int id) {

            Model.t_user model = userbll.GetModel(id);
            Model.user_role urmodel = user_rolebll.GetModels(model.id);
            Model.t_role rolemodel = rolebll.GetModel(urmodel.roleid);
            Model.role_permission rolepemodel = role_permissionbll.GetModels(rolemodel.id);
            Model.t_permission permmodel = t_permissionbll.GetModel(rolepemodel.permissionid);


            if (urmodel!=null)
            {
                user_rolebll.Delete(urmodel.id);
            }
                if (rolepemodel!=null)
            {
                role_permissionbll.Delete(rolepemodel.id);
            }
            if (model != null)
            {
                userbll.Delete(model.id);
            }
          
            //if (rolemodel != null)
            //{
            //    rolebll.Delete(rolemodel.id);
            //}
         
            if (permmodel != null)
            {
                t_permissionbll.Delete(permmodel.id);
            }
            return true;

        }

        #region 退出登录
        public ActionResult logout()
        {
            System.Web.HttpContext.Current.Session[NKeys.SESSION_USER_INFO] = null;
            Utils.WriteCookie(NKeys.COOKIE_USER_NAME_REMEMBER, "qinuo", "");
            Utils.WriteCookie(NKeys.COOKIE_USER_PWD_REMEMBER, "qinuo", "");
            return RedirectToAction("Login", "User");
        }
        #endregion


    }
}