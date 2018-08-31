using QiuoOA.Authorizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QiuoOA.Controllers
{
    [Authorizer]
    public class ComyanyADNBrandController : Controller
    {
        Bll.Company bll = new Bll.Company();
        Bll.Brand bll2 = new Bll.Brand();
        public ActionResult AddComyany()
        {
            return View();
        }
        [HttpPost]
        public JsonResult addcom(string Comyanyname,string name,string phone,string mail,string beizhu,string code) {
            string msg = addcoms(Comyanyname, name, phone, mail, beizhu, code);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string addcoms(string Comyanyname, string name, string phone, string mail, string beizhu, string code) {
            Model.Company model = new Model.Company();
            if (Comyanyname!=null && code!=null)
            {
                model.Name = Comyanyname;
                model.Contact = name;
                model.phone = phone;
                model.mail = mail;
                model.Remarks = beizhu;
                model.code = code;
                bll.Add(model);
                return "{\"status\": 1,\"msg\": \"添加成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\": \"错误提示:添加失败！\"}";
            }

        }
        public ActionResult AddBrand() {

            return View();
        }
        [HttpPost]
        public JsonResult addBrands(string Comyanyname, string code)
        {
            string msg = addBrandss(Comyanyname, code);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string addBrandss(string Comyanyname, string code)
        {
            Model.Brand model = new Model.Brand();
            if (Comyanyname != null && code != null)
            {
                model.Name = Comyanyname;
                model.code = code;
                bll2.Add(model);
                return "{\"status\": 1,\"msg\": \"添加成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\": \"错误提示:添加失败！\"}";
            }

        }

    }
}