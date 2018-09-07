using Cll;
using CustomerAttribute;
using Model;
using Newtonsoft.Json;
using NWJ.Cmn;
using QiuoOA.Authorizers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace QiuoOA.Controllers
{
    [Authorizer]
    public class HomeController : BaseController
    {
        Bll.t_user userbll = new Bll.t_user();
        Bll.t_role rolebll = new Bll.t_role();
        Bll.Brand brandbll = new Bll.Brand();
        Bll.Company companybll = new Bll.Company();
        Bll.Project Projectbll = new Bll.Project();
        Bll.Money Moneybll = new Bll.Money();
        Bll.ProjecTtype ProjecTtype = new Bll.ProjecTtype();
        Bll.Company Companybll = new Bll.Company();
        Bll.Brand Brand = new Bll.Brand();
        Bll.projectCostlujing projectCostlujingbll = new Bll.projectCostlujing();
        Bll.ProjectQuotationlujing ProjectQuotationlujingbll = new Bll.ProjectQuotationlujing();
        Bll.Paymentapplicationform Paymentapplicationformbll = new Bll.Paymentapplicationform();
        Bll.node nodebll = new Bll.node();
        Bll.PO pobll = new Bll.PO();
        Bll.ProjectFinalReport reportbll = new Bll.ProjectFinalReport();
        Bll.Publishlinksummary summarybll = new Bll.Publishlinksummary();
        Bll.user_role urbll = new Bll.user_role();
        public ActionResult Index()
        {
            ViewBag.islogin = IsUserLogin() ? 1 : 0;
            if (IsUserLogin())
            {
                Model.t_user model = GetUserInfo();
                if (model != null)
                {
                    ViewBag.name = model.name;
                    ViewBag.employeename = model.employeename;
                    user_role urmodel = urbll.GetModels(model.id);
                    t_role rolemodel = rolebll.GetModel(urmodel.roleid);
                    ViewBag.rolename = rolemodel.name;
                    ViewData["Project"] = Projectbll.GetModelList("1=1");
                    //AE所有人员
                    ViewData["AE"] = userbll.GetModelListss("26");
                    //SAE所有人员
                    ViewData["SAE"] = userbll.GetModelListss("27");
                    //AD所有人员
                    ViewData["AD"] = userbll.GetModelListss("28");
                    //SAD所有人员
                    ViewData["SAD"] = userbll.GetModelListss("29");
                    //营销总监所有人员
                    ViewData["yingxiao"] = userbll.GetModelListss("30");
                    //财务所有人员
                    ViewData["caiwu"] = userbll.GetModelListss("22");
                    //老板
                    ViewData["laoban"] = userbll.GetModelListss("1");
                    //朱老板
                    ViewData["zhulaoban"] = userbll.GetModelListss("1");
                }
                ViewData["Paymentapplicationform"] = Paymentapplicationformbll.GetModelList("1=1");
            }
            return View();
        }
        public ActionResult ProjectList()
        {
            Model.t_user model = GetUserInfo();
            if (model!=null)
            {
                ViewBag.employeename = model.employeename;
                if (model.name=="管理员")
                {
                    ViewData["projectlist"] = Projectbll.GetModelList("1=1");
                }
                else
                {
                    ViewData["projectlist"] = Projectbll.GetModelList("userid=" + model.id);
                }
            }
            return View();
        }
        [HttpPost]
        public JsonResult indexs(string name)
        {
            if (name != "")
            {
                Project Projectmodel = Projectbll.GetModelss(name);
                ProjecTtype ProjecTtypemodel = ProjecTtype.GetModel(Projectmodel.ProjecttypeId.Value);
                Company Companymodel = Companybll.GetModel(Projectmodel.CompanyId.Value);
                Brand Brandmodel = brandbll.GetModels(Companymodel.Id);
                t_user usermodel = userbll.GetModel(Projectmodel.userid.Value);
                Money moneymodel = Moneybll.GetModels(Projectmodel.Id);
                Model.projectCostlujing projectCostlujingmodel = projectCostlujingbll.GetModels(Projectmodel.Id);
                Model.ProjectQuotationlujing ProjectQuotationlujingmodel = ProjectQuotationlujingbll.GetModels(Projectmodel.Id);
                node nodesmodel = nodebll.GetfModels(Projectmodel.Id, 1);
                node nodemodel = nodebll.GetfModels(Projectmodel.Id,3);
                node nodemodels = nodebll.GetfModels(Projectmodel.Id,2);
                var catmodel = Paymentapplicationformbll.GetModelList("ProjectId=" + Projectmodel.Id+ " and ApplyforpaymentType!=''");
                //查询对个人
                var personalmodel= Paymentapplicationformbll.GetModelList("ProjectId=" + Projectmodel.Id+ " and shuidian is null and (ApplyforpaymentType is null or ApplyforpaymentType='')");
                //查询对公司
                var companymodel = Paymentapplicationformbll.GetModelList("ProjectId=" + Projectmodel.Id + " and (ApplyforpaymentType is null or ApplyforpaymentType='') and shuidian is not null");
                return Json
                    (new
                    {
                        Projectmodel,
                        ProjecTtypeName = ProjecTtypemodel.Name,
                        CompanyName = Companymodel.Name,
                        BrandName = Brandmodel.Name,
                        Username = usermodel.employeename,
                        moneymodel,
                        projectCostlujing = projectCostlujingmodel.projectCostUrl,
                        ProjectQuotationlujing = ProjectQuotationlujingmodel.ProjectQuotationUrl,
                        nodemodel,
                        catmodel,
                        personalmodel,
                        companymodel,
                        nodemodels,
                        nodesmodel
                    });
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        public static string SaveExcelFile(HttpPostedFile file)
        {

            try
            {
                var bianliang = System.Web.HttpContext.Current.Server.MapPath("~/Upload");
                var fileName = file.FileName.Insert(file.FileName.LastIndexOf('.'), "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                var filePath = Path.Combine(bianliang, fileName);
                string directoryName = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                file.SaveAs(filePath);
                return filePath;

            }
            catch
            {
                return string.Empty;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorizer]
        public ActionResult AddProject()
        {

            ViewBag.islogin = IsUserLogin() ? 1 : 0;
            if (IsUserLogin())
            {
                Model.t_user model = GetUserInfo();
                if (model != null)
                {
                    ViewBag.employeename = model.employeename;
                }
                ViewData["user"] = userbll.GetModelList("1=1");
                ViewData["company"] = companybll.GetModelList("1=1");
                ViewData["brand"] = brandbll.GetModelList("1=1");
                ViewData["Project"] = Projectbll.GetModelList("1=1");
                ViewData["ProjecTtype"] = ProjecTtype.GetModelList("1=1");
                ViewData["Project"] = Projectbll.GetModelList("1=1");
                //AE所有人员
                ViewData["AE"] = userbll.GetModelListss("26");
                //SAE所有人员
                ViewData["SAE"] = userbll.GetModelListss("27");
                //AD所有人员
                ViewData["AD"] = userbll.GetModelListss("28");
                //SAD所有人员
                ViewData["SAD"] = userbll.GetModelListss("29");
                //营销总监所有人员
                ViewData["yingxiao"] = userbll.GetModelListss("30");
                //财务所有人员
                ViewData["caiwu"] = userbll.GetModelListss("22");
                //老板
                ViewData["laoban"] = userbll.GetModelListss("1");
                //朱老板
                ViewData["zhulaoban"] = userbll.GetModelListss("1");
            }
            return View();
        }
        [HttpPost]
        public JsonResult AddProjects(string name, string core, string sele, string companyname, string pingpai, string core2, string xiangmuuser, string date, string date2, string Totalmoney, string Notaxmoney, string cost, string jingdu, string beizhu, string usname)
        {


            string msg = AddProjectss(name, core, sele, companyname, pingpai, core2, xiangmuuser, date, date2, Totalmoney, Notaxmoney, cost, jingdu, beizhu, usname);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult projectCostlujing()
        {
            var bianliang = System.Web.HttpContext.Current;
            bianliang.Response.ContentType = "text/plain";
            HttpPostedFile filePost = bianliang.Request.Files["filed"]; // 获取上传的文件  
            string filePath = SaveExcelFile(filePost); // 保存文件并获取文件路径
            Model.Project model = Projectbll.GetModels();
            Model.projectCostlujing projectCostlujingmodel = new Model.projectCostlujing();
            Bll.projectCostlujing bll = new Bll.projectCostlujing();
            projectCostlujingmodel.projectCostUrl = filePath;
            projectCostlujingmodel.ProjectId = model.Id;
            if (projectCostlujingmodel != null)
            {
                bll.Add(projectCostlujingmodel);
            }
            return Json(filePath, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ProjectQuotationlujing()
        {
            var bianliang1 = System.Web.HttpContext.Current;
            bianliang1.Response.ContentType = "text/plain";
            HttpPostedFile filePost1 = bianliang1.Request.Files["filed1"]; // 获取上传的文件  
            string filePath1 = SaveExcelFile(filePost1);
            if (filePost1 != null)
            {
                // 保存文件并获取文件路径
                Model.Project model = Projectbll.GetModels();
                Model.ProjectQuotationlujing ProjectQuotationlujingmodel = new Model.ProjectQuotationlujing();
                Bll.ProjectQuotationlujing bll = new Bll.ProjectQuotationlujing();
                ProjectQuotationlujingmodel.ProjectQuotationUrl = filePath1;
                ProjectQuotationlujingmodel.ProjectId = model.Id;
                if (ProjectQuotationlujingmodel != null)
                {
                    bll.Add(ProjectQuotationlujingmodel);
                }
            }

            return Json(filePath1, JsonRequestBehavior.AllowGet);
        }

        private string AddProjectss(string name, string core, string sele, string companyname, string pingpai, string core2, string xiangmuuser, string date, string date2, string Totalmoney, string Notaxmoney, string cost, string jingdu, string beizhu, string usname)
        {
            Model.Project model = new Model.Project();
            Model.ProjecTtype Ttypemodel = new Model.ProjecTtype();
            Model.Company Companymodel = new Model.Company();
            Model.Brand Brandmodel = new Model.Brand();
            Model.Money Moneymodel = new Model.Money();
            if (name != null && core != null && sele != null && companyname != null && pingpai != null && core2 != null && xiangmuuser != null && date != null && date2 != null && Totalmoney != null && Notaxmoney != null && cost != null)
            {
                Ttypemodel.Name = sele; //项目类型
                Ttypemodel.USName = usname;
                Companymodel.Name = companyname;//公司名称
                Brandmodel.Name = pingpai;//品牌名称
                if (Ttypemodel.Name != null)
                {
                    ProjecTtype.Add(Ttypemodel);
                }
                //添加公司表
                if (Companymodel.Name != null)
                {
                    Companybll.Add(Companymodel);
                }
                //添加品牌表
                if (Brandmodel.Name != null)
                {
                    Companymodel = Companybll.GetModels();
                    Brandmodel.CompanyId = Companymodel.Id;
                    brandbll.Add(Brandmodel);
                }

                Model.t_user usermodel = userbll.GetModelsss(xiangmuuser);
                model.ProjectName = name; //项目名称
                model.ProjectCode = core; //项目代码
                model.PurchaseSingleCode = core2;//采购单码

                model.ProjectStartDate = Convert.ToDateTime(date);//开始时间
                model.ProjectEndDate = Convert.ToDateTime(date2);//结束时间
                model.CompanyId = Companymodel.Id;
                Ttypemodel = ProjecTtype.GetModels();
                model.ProjecttypeId = Ttypemodel.Id;
                if (usermodel != null)
                {
                    model.userid = usermodel.id;//项目负责人
                }
                model.Remarks = beizhu; //备注
                model.Planprogress = jingdu; //计划进度
                Projectbll.Add(model);

                model = Projectbll.GetModels();
                Moneymodel.projectcost = Convert.ToDecimal(cost); //项目成本
                Moneymodel.TotalMoney = Convert.ToDecimal(Totalmoney);//非税金额
                Moneymodel.NoTaxlMoney = Convert.ToDecimal(Notaxmoney);//含税金额
                Moneymodel.ProjectId = model.Id; //项目id
                if (Moneymodel != null)
                {
                    Moneybll.Add(Moneymodel);
                }

                return "{\"status\": 1,\"msg\":\"申请成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\":\"申请失败！\"}";
            }


        }

        //对个人付款
        [Authorizer]
        public ActionResult PersonalPayment(string projectname, string wangming, string xuhao)
        {
            if (projectname != null && wangming != null)
            {
                Model.Project model = Projectbll.GetModelss(projectname);
                ViewBag.wangming = wangming;
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public JsonResult PersonalPayments(string ZFjine, string ZFdate, string shoukuanren, string kaihuhang, string Bankcode, string projectname, string Paymentobject, string xuhao, string leixing, string beizhu, string chenbenbaojia, string xiaoshoubaojia, string wangming, string chenbenbaojia2,string Distinguish,string chenbenleibie,string yongtu, string pingtai, string chenbenbaojia1, string xiaoshoubaojia1)
        {
            string msg = PersonalPaymentss(ZFjine, ZFdate, shoukuanren, kaihuhang, Bankcode, projectname, Paymentobject, xuhao, leixing, beizhu, chenbenbaojia, xiaoshoubaojia, wangming, chenbenbaojia2, Distinguish, chenbenleibie, yongtu,pingtai, chenbenbaojia1, xiaoshoubaojia1);
            Project model = Projectbll.GetModelss(projectname);
            Model.Paymentapplicationform formmodel = Paymentapplicationformbll.GetModelsDistinguish(model.Id, xuhao, Distinguish);
            return Json(new { msg, formmodel });

        }
        private string PersonalPaymentss(string ZFjine, string ZFdate, string shoukuanren, string kaihuhang, string Bankcode, string projectname, string Paymentobject, string xuhao, string leixing, string beizhu, string chenbenbaojia, string xiaoshoubaojia, string wangming, string chenbenbaojia2,string Distinguish, string chenbenleibie, string yongtu,string pingtai, string chenbenbaojia1, string xiaoshoubaojia1)
        {
            //数据库加一个区分字段 1,2,3 然后页面添加的时候传过来这个字段用这个字段+序号+项目ID查询，有就修改没有添加，不用管是A还是B还是C，
            //页面绑定数据加隐藏域获取区分字段以便于修改能定位到该数据
            Model.Paymentapplicationform Paymentapplicationmodel = new Paymentapplicationform();
            Project model = Projectbll.GetModelss(projectname);
            var xuhaopanduan = Paymentapplicationformbll.Exists(Convert.ToInt32(xuhao), model.Id);
            Model.Paymentapplicationform Paymentapplicationmodel1 = Paymentapplicationformbll.GetModelsDistinguish(model.Id, xuhao, Distinguish);
            if (Paymentapplicationmodel1 == null)
            {
                if (projectname != null && ZFjine != null && ZFdate != null && Bankcode != null && ZFdate != null && shoukuanren != null && kaihuhang != null)
                {

                    Paymentapplicationmodel.ProjectId = model.Id; //项目ID
                    Paymentapplicationmodel.Timeofpayment = Convert.ToDateTime(ZFdate);//付款时间
                    Paymentapplicationmodel.Openingbank = kaihuhang;//开户行
                    Paymentapplicationmodel.Bankaccount = Bankcode;//银行账号
                    Paymentapplicationmodel.Paymentobject = Paymentobject;//支付对象
                    Paymentapplicationmodel.xuhao = Convert.ToInt32(xuhao); //序号
                    Paymentapplicationmodel.ApplyforpaymentType = leixing; //类型
                    Paymentapplicationmodel.Payee = shoukuanren;//收款人
                    Paymentapplicationmodel.Remarks = beizhu;
                    Model.Money moneymodel = Moneybll.GetModels(model.Id);
                    Paymentapplicationmodel.MoneyId = moneymodel.Id; //金额ID
                    Paymentapplicationmodel.Actualamountofpayment = Convert.ToDecimal(ZFjine);//应支付金额
                    Paymentapplicationmodel.CostQuotation = Convert.ToDecimal(chenbenbaojia);//成本报价
                    Paymentapplicationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia);//销售报价
                    Paymentapplicationmodel.Distinguish = Convert.ToInt32(Distinguish); // Paymentapplicationmodel.Financialcost = Convert.ToDecimal(caiwuchengben);//财务成本
                    if (wangming!="" && wangming!=null)
                    {
                        Paymentapplicationmodel.wangming = wangming;
                    }
                    Paymentapplicationmodel.Costcategory = chenbenleibie;
                    Paymentapplicationmodel.purpose = yongtu;
                    Paymentapplicationmodel.Distinguish=Convert.ToInt32(Distinguish);
                    Paymentapplicationmodel.pingtai = pingtai;
                    Paymentapplicationformbll.Add(Paymentapplicationmodel);

                    return "{\"status\": 1,\"msg\":\"消息提示:添加成功！\"}";
                }
                else
                {
                    return "{\"status\": 0,\"msg\":\"消息提示:添加失败！\"}";
                }
            }
            else if (Paymentapplicationmodel1 != null)
            {
                Model.Paymentapplicationform cationmodel = Paymentapplicationformbll.GetModelsDistinguish(model.Id, xuhao, Distinguish);
                cationmodel.ProjectId = model.Id; //项目ID
                cationmodel.Timeofpayment = Convert.ToDateTime(ZFdate);//付款时间
                cationmodel.Openingbank = kaihuhang;//开户行
                cationmodel.Bankaccount = Bankcode;//银行账号
                cationmodel.Paymentobject = Paymentobject;//支付对象
                cationmodel.xuhao = Convert.ToInt32(xuhao); //序号
                cationmodel.ApplyforpaymentType = leixing; //类型
                cationmodel.Payee = shoukuanren;//收款人
                cationmodel.Remarks = beizhu;
                Model.Money moneymodel = Moneybll.GetModels(model.Id);
                cationmodel.MoneyId = moneymodel.Id; //金额ID
                if (chenbenbaojia1 != "")
                {
                    cationmodel.CostQuotation = Convert.ToDecimal(chenbenbaojia1);//成本报价

                }
                else
                {
                    cationmodel.CostQuotation = Convert.ToDecimal(chenbenbaojia);//成本报价
                }
                if (xiaoshoubaojia1 != "")
                {
                    cationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia1);//销售报价

                }
                else
                {
                    cationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia);//销售报价
                }
                cationmodel.Actualamountofpayment = Convert.ToDecimal(ZFjine);//应支付金额
                //if (caiwuchengben != null&& caiwuchengben != "")
                //{
                //    cationmodel.Financialcost = Convert.ToDecimal(caiwuchengben);//财务成本
                //}
                if (chenbenbaojia2 != "" && chenbenbaojia2 != null)
                {
                    cationmodel.Financialcost = Convert.ToDecimal(chenbenbaojia2);//财务成本2
                }
                cationmodel.wangming = wangming;
                cationmodel.Distinguish = Convert.ToInt32(Distinguish);
                cationmodel.Costcategory = chenbenleibie;
                cationmodel.purpose = yongtu;
                    cationmodel.pingtai = pingtai;
                //cationmodel.Totaltaxcost = Convert.ToDecimal(hanshuichenbenheji);//含税成本合计
                Paymentapplicationformbll.Update(cationmodel);

                return "{\"status\": 1,\"msg\":\"消息提示:修改成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\":\"消息提示:修改失败！\"}";
            }

        }
        //对公司付款
        [Authorizer]
        public ActionResult PaymentCompany(string projectname, string wangming, string xuhao)
        {
            if (projectname != null && wangming != null && xuhao != null)
            {
                Model.Project model = Projectbll.GetModelss(projectname);
                ViewBag.wangming = wangming;
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public JsonResult PaymentCompanys(string pingtai1,string chenbenbaojia1,string xiaoshoubaojia1,string suidian1, string ZFjine, string fapiao, string fapiaosuie, string ZFdate, string gsname, string kaihuhang, string Bankcode, string projectname, string Paymentobject, string xuhao, string leixing, string beizhu, string suidian, string chenbenbaojia, string xiaoshoubaojia, string wangming, string chenbenbaojia2,string Distinguish, string chenbenleibie, string yongtu,string pingtai)
        {
            string msg = PaymentCompanyss(pingtai1, chenbenbaojia1, xiaoshoubaojia1, suidian1, ZFjine, fapiao, fapiaosuie, ZFdate, gsname, kaihuhang, Bankcode, projectname, Paymentobject, xuhao, leixing, beizhu, suidian, chenbenbaojia, xiaoshoubaojia, wangming, chenbenbaojia2, Distinguish, chenbenleibie, yongtu, pingtai);
            Project model = Projectbll.GetModelss(projectname);
            Model.Paymentapplicationform formmodel = Paymentapplicationformbll.GetModelsDistinguish(model.Id, xuhao, Distinguish);
            return Json(new { msg, formmodel });
            // return Json(msg, formmodel, JsonRequestBehavior.AllowGet);

        }
        private string PaymentCompanyss(string pingtai1, string chenbenbaojia1, string xiaoshoubaojia1, string suidian1, string ZFjine, string fapiao, string fapiaosuie, string ZFdate, string gsname, string kaihuhang, string Bankcode, string projectname, string Paymentobject, string xuhao, string leixing, string beizhu, string suidian, string chenbenbaojia, string xiaoshoubaojia, string wangming, string chenbenbaojia2,string Distinguish, string chenbenleibie, string yongtu,string pingtai)
        {
            Model.Paymentapplicationform Paymentapplicationmodel = new Paymentapplicationform();
            Project model = Projectbll.GetModelss(projectname);
            var xuhaopanduan = Paymentapplicationformbll.Exists(Convert.ToInt32(xuhao), model.Id);
            Model.Paymentapplicationform Paymentapplicationmodel1 = Paymentapplicationformbll.GetModelsDistinguish(model.Id, xuhao, Distinguish);
            //数据库加一个区分字段 1,2,3 然后页面添加的时候传过来这个字段用这个字段+序号+项目ID查询，有就修改没有添加，不用管是A还是B还是C，
            //页面绑定数据加隐藏域获取区分字段以便于修改能定位到该数据
            if (Paymentapplicationmodel1 == null)
            {
                if (projectname != null && ZFjine != null && fapiao != null && fapiaosuie != null && ZFdate != null && gsname != null && kaihuhang != null)
                {
                    Paymentapplicationmodel.ProjectId = model.Id; //项目ID
                    Paymentapplicationmodel.Invoicenumber = Convert.ToInt32(fapiao);//发票号
                    Paymentapplicationmodel.Invoicetax = Convert.ToDecimal(fapiaosuie);//发票税额
                    Paymentapplicationmodel.Timeofpayment = Convert.ToDateTime(ZFdate);//付款时间
                    Paymentapplicationmodel.Receivablescompany = gsname;//收款公司
                    Paymentapplicationmodel.Openingbank = kaihuhang;//开户行
                    Paymentapplicationmodel.Bankaccount = Bankcode;//银行账号
                    Paymentapplicationmodel.Paymentobject = Paymentobject;//支付对象
                    Paymentapplicationmodel.xuhao = Convert.ToInt32(xuhao); //序号
                    Paymentapplicationmodel.ApplyforpaymentType = leixing; //类型
                    Paymentapplicationmodel.Remarks = beizhu;
                    Model.Money moneymodel = Moneybll.GetModels(model.Id);
                    Paymentapplicationmodel.MoneyId = moneymodel.Id; //金额ID
                    Paymentapplicationmodel.Actualamountofpayment = Convert.ToDecimal(ZFjine);//应支付金额
                    Paymentapplicationmodel.CostQuotation = Convert.ToDecimal(chenbenbaojia);//成本报价
                    if (xiaoshoubaojia=="申请")
                    {
                        Paymentapplicationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia1);
                    }
                    else { 
                        Paymentapplicationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia);//销售报价
                    }
                    //Paymentapplicationmodel.Financialcost= Convert.ToDecimal(caiwuchengben);//财务成本
                    Paymentapplicationmodel.shuidian = Convert.ToDecimal(suidian);//税点
                    Paymentapplicationmodel.pingtai = pingtai;
                    if (wangming!="" && wangming!=null)
                    {
                        Paymentapplicationmodel.wangming = wangming;
                    }
                    Paymentapplicationmodel.Costcategory = chenbenleibie;
                    Paymentapplicationmodel.purpose = yongtu;
                    Paymentapplicationmodel.Distinguish = Convert.ToInt32(Distinguish);
                    Paymentapplicationformbll.Add(Paymentapplicationmodel);

                    return "{\"status\": 1,\"msg\":\"消息提示:添加成功！\"}";
                }
                else
                {
                    return "{\"status\": 0,\"msg\":\"消息提示:添加失败！\"}";
                }
            }
            else if (Paymentapplicationmodel1 != null)
            {
                Model.Paymentapplicationform cationmodel = Paymentapplicationformbll.GetModelsDistinguish(model.Id, xuhao, Distinguish);
                cationmodel.ProjectId = model.Id; //项目ID
                cationmodel.Invoicenumber = Convert.ToInt32(fapiao);//发票号
                cationmodel.Invoicetax = Convert.ToDecimal(fapiaosuie);//发票税额
                cationmodel.Timeofpayment = Convert.ToDateTime(ZFdate);//付款时间
                cationmodel.Receivablescompany = gsname;//收款公司
                cationmodel.Openingbank = kaihuhang;//开户行
                cationmodel.Bankaccount = Bankcode;//银行账号
                cationmodel.Paymentobject = Paymentobject;//支付对象
                cationmodel.xuhao = Convert.ToInt32(xuhao); //序号
                cationmodel.ApplyforpaymentType = leixing; //类型
                cationmodel.Remarks = beizhu;
                Model.Money moneymodel = Moneybll.GetModels(model.Id);
                cationmodel.MoneyId = moneymodel.Id; //金额ID
                cationmodel.Actualamountofpayment = Convert.ToDecimal(ZFjine);//应支付金额
                if (chenbenbaojia1 != "")
                {
                    cationmodel.CostQuotation = Convert.ToDecimal(chenbenbaojia1);//成本报价

                }
                else
                {
                    cationmodel.CostQuotation = Convert.ToDecimal(chenbenbaojia);//成本报价
                }
                if (xiaoshoubaojia1!="")
                {
                    cationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia1);//销售报价

                }
                else
                {
                    cationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia);//销售报价
                }
                //if (caiwuchengben != null)
                //{
                //    cationmodel.Financialcost = Convert.ToDecimal(caiwuchengben);//财务成本
                //}
                if (chenbenbaojia2 != "" && chenbenbaojia2 != null)
                {
                    cationmodel.Financialcost = Convert.ToDecimal(chenbenbaojia2);//财务成本2
                }
                if (suidian1!="")
                {
                    cationmodel.shuidian = Convert.ToDecimal(suidian1);//税点

                }
                else
                {
                    cationmodel.shuidian = Convert.ToDecimal(suidian);//税点
                }
                cationmodel.wangming = wangming;
                cationmodel.Distinguish = Convert.ToInt32(Distinguish);
                cationmodel.Costcategory = chenbenleibie;
                cationmodel.purpose = yongtu;
                if (pingtai1!="")
                {
                    cationmodel.pingtai = pingtai1;
                }
                else
                {
                    cationmodel.pingtai = pingtai;
                }
                //  cationmodel.Totaltaxcost = Convert.ToDecimal(hanshuichenbenheji);//含税成本合计
                Paymentapplicationformbll.Update(cationmodel);

                return "{\"status\": 1,\"msg\":\"消息提示:修改成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\":\"消息提示:修改失败！\"}";
            }
        }
        //修改按钮回显数据
        [HttpPost]
        public JsonResult updateview(string xuhao, string projectname,string Distinguish)
        {
            if (xuhao != null && projectname != null)
            {
                Project projectmodel = Projectbll.GetModelss(projectname);
                Paymentapplicationform model = Paymentapplicationformbll.GetModelsDistinguish(projectmodel.Id, xuhao, Distinguish);
                return Json(new { model });
            }
            else
            {
                return Json("错误");
            }

        }


        //打开项目报价表
        [HttpPost]
        public JsonResult projectCostlujingFile(string projectCostlujingFiless)
        {
            string msg = projectCostlujingFiles(projectCostlujingFiless);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string projectCostlujingFiles(string projectCostlujingFiless)
        {
            if (projectCostlujingFiless != null)
            {
                System.Diagnostics.Process.Start(projectCostlujingFiless);
                return "{\"status\": 1,\"msg\":\"消息提示:打开成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\":\"消息提示:打开失败！\"}";
            }
        }

        //打开项目成本表
        [HttpPost]
        public JsonResult projectQuotationlujingFile(string projectQuotationlujingFiless)
        {
            string msg = projectQuotationlujingFiles(projectQuotationlujingFiless);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string projectQuotationlujingFiles(string projectQuotationlujingFiless)
        {
            if (projectQuotationlujingFiless != null)
            {
                System.Diagnostics.Process.Start(projectQuotationlujingFiless);
                return "{\"status\": 0,\"msg\":\"消息提示:打开成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\":\"消息提示:打开失败！\"}";
            }
        }
        //添加(修改)明细表
        [HttpPost]
        public JsonResult mixibaocun(string beizu, string xsbjhj, string sjhj, string Noheji, string heji, string maolirun, string Nozhifu, string yuangongjiangjin, string weifenpeilirun, string lirunbaifenbi, string prijectname, string po, string Expectedreturndate, string Actualdate, string daozhangjine, string AMargemBrutapercentual, string Olucrolíquido, string Aporcentagemdelucrolíquido)
        {
            string msg = mixibaocuns(beizu, xsbjhj, sjhj, Noheji, heji, maolirun, Nozhifu, yuangongjiangjin, weifenpeilirun, lirunbaifenbi, prijectname, po, Expectedreturndate, Actualdate, daozhangjine, AMargemBrutapercentual, Olucrolíquido, Aporcentagemdelucrolíquido);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string mixibaocuns(string beizu, string xsbjhj, string sjhj, string Noheji, string heji, string maolirun, string Nozhifu, string yuangongjiangjin, string weifenpeilirun, string lirunbaifenbi, string prijectname, string po, string Expectedreturndate, string Actualdate, string daozhangjine, string AMargemBrutapercentual, string Olucrolíquido, string Aporcentagemdelucrolíquido)
        {
            Project promodel = Projectbll.GetModelss(prijectname);
            Money moneymodel = Moneybll.GetModels(promodel.Id);
            // Model.Paymentapplicationform cationmodel = Paymentapplicationformbll.GetModels(promodel.Id, xuhao);
            if (promodel != null)
            {
                promodel.Remarks = beizu;
                promodel.Expectedreturndate = Convert.ToDateTime(Expectedreturndate);
                promodel.Actualdate = Convert.ToDateTime(Actualdate);
                promodel.POdanhao = po;
                promodel.Accountamount = Convert.ToDecimal(daozhangjine);
                Projectbll.Update(promodel);
            }
            if (moneymodel != null)
            {
                if (xsbjhj!="")
                {
                    moneymodel.SalesQuotations = Convert.ToDecimal(xsbjhj);//销售报价合计
                }
                if (sjhj != null && sjhj != "")
                {
                    moneymodel.TaxSum = Convert.ToDecimal(sjhj);//税金合计
                }
                moneymodel.NonTaxCostCombined = Convert.ToDecimal(Noheji); //不含税成本合计
                if (heji!=null && heji!="")
                {
                    moneymodel.Totaltaxcosttow = Convert.ToDecimal(heji);//含税成本合计
                }
                moneymodel.Grossprofit = Convert.ToDecimal(maolirun);//毛利润
                if (Nozhifu!="")
                {
                moneymodel.Unpaidchannel = Convert.ToDecimal(Nozhifu); //未支付渠道款
                }
                if (yuangongjiangjin!="")
                {
                    moneymodel.Employeebonus = Convert.ToDecimal(yuangongjiangjin);//员工奖金
                }
                if (weifenpeilirun!="")
                {
                    moneymodel.Undistributedprofit = Convert.ToDecimal(weifenpeilirun);//未分配利润
                }
                moneymodel.Percentageofprofit = lirunbaifenbi;//利润百分比
                moneymodel.AMargemBrutapercentual = AMargemBrutapercentual;
                if (Olucrolíquido!="")
                {
                    moneymodel.Olucrolíquido = Convert.ToDecimal(Olucrolíquido);
                }
                if (Aporcentagemdelucrolíquido!="")
                {
                    moneymodel.Aporcentagemdelucrolíquido = Aporcentagemdelucrolíquido;
                }
                //if (cationmodel!=null)
                //{
                //    cationmodel.Financialcost = Convert.ToDecimal(chenben);//财务成本2
                //    Paymentapplicationformbll.Update(cationmodel);
                //}
                Moneybll.Update(moneymodel);
                return "{\"status\": 1,\"msg\":\"消息提示:添加成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\":\"消息提示:添加失败！\"}";
            }

        }
        //审批提交
        [HttpPost]
        public JsonResult shenpi(string projectname,string processstate,string xuhao,string Distinguish)
        {
            string msg = shenpis(projectname, processstate, xuhao, Distinguish);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string shenpis(string projectname,string processstate, string xuhao, string Distinguish)
        {
            Project projectmodel = Projectbll.GetModelss(projectname);
            Paymentapplicationform formmodel = Paymentapplicationformbll.GetModelsDistinguish(projectmodel.Id, xuhao, Distinguish);
            Model.t_user usermodel = GetUserInfo();
            Model.t_user usermodel1 = userbll.GetModel(projectmodel.userid.Value);
            Bll.node nodebll = new Bll.node();
            node model = new node();
            model = nodebll.GetfModels(projectmodel.Id, Convert.ToInt32(processstate));
            //if (Distinguish=="2"&& model.Stateofapproval!=0)
            //{
            //    return "{\"status\": 12,\"msg\":\"上次审批未审批通过!\"}";
            //}
            if (processstate=="2"&& formmodel.readState==1)
            {
                return "{\"status\": 13,\"msg\":\"审批已通过!\"}";
            }
            if (projectmodel.typefinished == 1)
            {
                return "{\"status\": 0,\"msg\":\"此项目已结案!\"}";
            }
            if (model != null)
            {
                //if (model.Stateofapproval==1&& usermodel.employeename== usermodel1.employeename)
                //{
                //    return "{\"status\": 0,\"msg\":\"您是当前项目负责人已经审批过了!\"}";
                //}
                    if (model.Stateofapproval == 0)
                    {
                        model.Stateofapproval = 1;
                        nodebll.Update(model);
                        return "{\"status\": 1,\"msg\":\"项目负责人审批成功!\"}";
                    }
                //if (model.AE=="" && model.Stateofapproval == 1)
                //{
                //    model.Stateofapproval = 2;
                //    nodebll.Update(model);
                //}
                //else if (model.AE == usermodel.employeename && model.Stateofapproval == 1)
                //{
                //    model.Stateofapproval = 2;
                //    nodebll.Update(model);
                //    return "{\"status\": 2,\"msg\":\"AE审批成功\"}";
                //}
                if (model.SAE=="" && model.Stateofapproval==1)
                {
                    model.Stateofapproval = 3;
                    nodebll.Update(model);
                }
                else if (model.SAE == usermodel.employeename && model.Stateofapproval == 1)
                {
                    model.Stateofapproval = 3;
                    nodebll.Update(model);
                    return "{\"status\": 3,\"msg\":\"SAE审批成功\"}";

                }
                if (model.AD=="" && model.Stateofapproval==3)
                {
                    model.Stateofapproval = 4;
                    nodebll.Update(model);
                }
                else if (model.AD == usermodel.employeename && model.Stateofapproval == 3)
                {
                    model.Stateofapproval = 4;
                    nodebll.Update(model);
                    return "{\"status\": 4,\"msg\":\"AD审批成功\"}";
                }
                if (model.SAD=="" && model.Stateofapproval == 4)
                {
                    model.Stateofapproval = 5;
                    nodebll.Update(model);
                }
                else if (model.SAD == usermodel.employeename && model.Stateofapproval == 4)
                {
                    model.Stateofapproval = 5;
                    nodebll.Update(model);
                    return "{\"status\": 5,\"msg\":\"SAD审批成功\"}";
                }
                if (model.yinxiaozongjian=="" && model.Stateofapproval == 5)
                {
                    model.Stateofapproval = 6;
                    nodebll.Update(model);
                }
                else if (model.yinxiaozongjian == usermodel.employeename && model.Stateofapproval == 5)
                {
                    model.Stateofapproval = 6;
                    nodebll.Update(model);
                    return "{\"status\": 6,\"msg\":\"营销负责人审批成功\"}";
                }
                if (model.caiwu=="" && model.Stateofapproval == 6)
                {
                    model.Stateofapproval = 8;
                    nodebll.Update(model);
                }
                else if (model.caiwu == usermodel.employeename && model.Stateofapproval == 6)
                {
                    model.Stateofapproval = 8;
                    nodebll.Update(model);
                    return "{\"status\": 8,\"msg\":\"财务审批成功\"}";
                }
              //if (model.laoban == usermodel.employeename && model.Stateofapproval == 7)
              //  {
              //      model.Stateofapproval = 8;
              //      nodebll.Update(model);
              //      return "{\"status\": 8,\"msg\":\"老板审批成功\"}";
              //  }
               if (model.zhulaoban == usermodel.employeename && model.Stateofapproval == 8)
                {
                    if (processstate=="2")
                    {
                        model.Stateofapproval = 0;
                        formmodel.readState = 1;
                        Paymentapplicationformbll.Update(formmodel);
                        nodebll.Update(model);
                        return "{\"status\":15,\"msg\":\"当前付款,审批成功!\"}";
                    }
                    else if(processstate=="3")
                    {
                        model.Stateofapproval = 9;
                        projectmodel.typefinished = 1;
                        Projectbll.Update(projectmodel);
                        nodebll.Update(model);
                        return "{\"status\": 9,\"msg\":\"审批成功,已结案!\"}";
                    }
                    else if (processstate=="1")
                    {
                        model.Stateofapproval = 9;
                        projectmodel.caseclosed = 1;
                        Projectbll.Update(projectmodel);
                        nodebll.Update(model);
                        return "{\"status\": 14,\"msg\":\"审批成功,已立案!\"}";
                    }
                }
                return "{\"status\": 10,\"msg\":\"您的上一审批人未审批,或您已审批或您没有权限\"}";
            }
            else
            {
                return "{\"status\": 11,\"msg\":\"审批失败\"}";
            }
        }
        //保存当前项目的审批人
        [HttpPost]
        public JsonResult shenpiren(string ae, string sae, string ad, string sad, string yingxiao, string caiwu, string laoban, string zhulaoban,string processstate)
        {
            string msg = shenpirens(ae, sae, ad, sad, yingxiao, caiwu, laoban, zhulaoban, processstate);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string shenpirens(string ae, string sae, string ad, string sad, string yingxiao, string caiwu, string laoban, string zhulaoban,string processstate)
        {
            Bll.node nodebll = new Bll.node();
            node model = new node();
            Project projectmodel = Projectbll.GetModels();
            Model.t_user usermodel = GetUserInfo();
            //if (projectmodel.userid != usermodel.id)
            //{
            //    return "您没有权限添加当前项目的审批人!";
            //}
            if (projectmodel != null)
            {
                JavaScriptSerializer jsonSerialzer = new JavaScriptSerializer();
                string[] retObj = jsonSerialzer.Deserialize<string[]>(ae);
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < retObj.Length; i++)
                {
                    str.Append(retObj[i] + ",");
                }
                model.projectid = projectmodel.Id;
                model.AE = str.ToString();
                model.SAE = sae;
                model.AD = ad;
                model.SAD = sad;
                model.yinxiaozongjian = yingxiao;
                model.caiwu = caiwu;
                model.laoban = laoban;
                model.zhulaoban = zhulaoban;
                model.Stateofapproval = 0;
                //插入三条数据
                model.processstate = Convert.ToInt32(processstate);
                nodebll.Add(model);
                model.processstate = Convert.ToInt32(processstate) + 2;
                nodebll.Add(model);

                return "成功添加当前项目审批人!";
            }
            else
            {
                return "添加当前项目审批人失败!";
            }
        }

        [HttpPost]
        public JsonResult Updatechaiwuchenben1(string xuhao, string caiwuchengben, string proname, string Distinguish, string hansuiheji)
        {
            Project promodle = Projectbll.GetModelss(proname);
            string msg = Updatechaiwuchenbens(xuhao, caiwuchengben, proname, Distinguish, hansuiheji);
            Paymentapplicationform frommodel = Paymentapplicationformbll.GetModelsDistinguish(promodle.Id, xuhao, Distinguish);
            return Json(new{ msg, frommodel });
        }
        private string Updatechaiwuchenbens(string xuhao, string caiwuchengben, string proname,string Distinguish, string hansuiheji)
        {
            Project promodle = Projectbll.GetModelss(proname);
            Paymentapplicationform frommodel = Paymentapplicationformbll.GetModelsDistinguish(promodle.Id, xuhao, Distinguish);
            if (frommodel != null)
            {
                frommodel.Financialcost = Convert.ToDecimal(caiwuchengben);
               // frommodel.Totaltaxcost = (frommodel.Actualamountofpayment) + Convert.ToDecimal(caiwuchengben);
                frommodel.Totaltaxcost = Convert.ToDecimal(hansuiheji);//含税成本合计

                Paymentapplicationformbll.Update(frommodel);
                return "{\"status\": 1,\"msg\":\"消息提示:修改成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\":\"消息提示:修改失败！\"}";
            }
        }


        [HttpPost]
        public JsonResult Updatechaiwuchenben(string xuhao, string caiwuchengben, string proname, string Distinguish)
        {
            Project promodle = Projectbll.GetModelss(proname);
            string msg = Updatechaiwuchenbens1(xuhao, caiwuchengben, proname, Distinguish);
            Paymentapplicationform frommodel = Paymentapplicationformbll.GetModelsDistinguish(promodle.Id, xuhao, Distinguish);
            return Json(new { msg, frommodel });
        }
        private string Updatechaiwuchenbens1(string xuhao, string caiwuchengben, string proname, string Distinguish)
        {
            Project promodle = Projectbll.GetModelss(proname);
            Paymentapplicationform frommodel = Paymentapplicationformbll.GetModelsDistinguish(promodle.Id, xuhao, Distinguish);
            if (frommodel != null)
            {
                frommodel.Financialcost = Convert.ToDecimal(caiwuchengben);
                 frommodel.Totaltaxcost = (frommodel.Actualamountofpayment) + Convert.ToDecimal(caiwuchengben);
                Paymentapplicationformbll.Update(frommodel);
                return "{\"status\": 1,\"msg\":\"消息提示:修改成功！\"}";
            }
            else
            {
                return "{\"status\": 0,\"msg\":\"消息提示:修改失败！\"}";
            }
        }

        //[HttpPost]
        //public JsonResult Updatepaystate(string xuhao,string proname, string Distinguish) {
        //    Project promodle = Projectbll.GetModelss(proname);
        //    string msg = Updatepaystates(xuhao, proname, Distinguish);
        //    Paymentapplicationform frommodel = Paymentapplicationformbll.GetModelsDistinguish(promodle.Id, xuhao, Distinguish);
        //    return Json(new { msg, frommodel });
        //}
        //private string Updatepaystates(string xuhao, string proname, string Distinguish) {
        //    Project promodle = Projectbll.GetModelss(proname);
        //    Paymentapplicationform frommodel = Paymentapplicationformbll.GetModelsDistinguish(promodle.Id, xuhao, Distinguish);
        //    node nodemodel = nodebll.GetModelsprocessstate(promodle.Id,2);
        //    if (frommodel != null)
        //    {
        //        frommodel.paystate = 1;
        //        nodemodel.Stateofapproval = 0;
        //        nodebll.Update(nodemodel);
        //        Paymentapplicationformbll.Update(frommodel);
        //        return "{\"status\": 1,\"msg\":\"消息提示:修改成功！\"}";
        //    }
        //    else
        //    {
        //        return "{\"status\": 0,\"msg\":\"消息提示:修改失败！\"}";
        //    }
        //}
    }
}