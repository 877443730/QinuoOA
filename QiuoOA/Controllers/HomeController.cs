using Cll;
using Model;
using QiuoOA.Authorizers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
        Bll.Paymentnode Paymentnodebll = new Bll.Paymentnode();
        Bll.node nodebll = new Bll.node();
        Bll.PO pobll = new Bll.PO();
        Bll.ProjectFinalReport reportbll = new Bll.ProjectFinalReport();
        Bll.Publishlinksummary summarybll = new Bll.Publishlinksummary();
        Bll.user_role urbll = new Bll.user_role();
        public ActionResult Index(string projectname)
        {
            ViewBag.islogin = IsUserLogin() ? 1 : 0;
            if (IsUserLogin())
            {
                Model.t_user model = GetUserInfo();
                if (model != null)
                {
                    ViewBag.projectname = projectname;
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
                //var model5 = Projectbll.getcesshi("1025");
            }
            return View();

        }
        public ActionResult cheshi() {
            return View();
        }
        public ActionResult Unapproved() {
            ViewBag.islogin = IsUserLogin() ? 1 : 0;
            if (IsUserLogin())
            {
                Model.t_user model = GetUserInfo();
                if (model != null)
                {
                    ViewBag.employeename = model.employeename;
                    //查询需要该当前登录人审批的项目信息
                    //立项
                    ViewData["lixiang"] = nodebll.GetModelLists("a.processstate=1");
                    //结案
                    ViewData["jiean"] = nodebll.GetModelLists("a.processstate=3");
                    //付款审批
                    ViewData["fukuan"] = Paymentnodebll.GetModelLists("1=1");
                    //未通过审批项
                    ViewData["Nofukuan"] = Paymentnodebll.GetModelLists("1=1 and Rejection!=''");
                }
            }
            return View();
        }
        public ActionResult ProjectList(string proname, int count)
        {
            Model.t_user model = GetUserInfo();
            if (model != null)
            {
                ViewBag.employeename = model.employeename;
                string projectids = "0";
                List<node> nodes = nodebll.GetModelList("AE like '%" + model.employeename + "%' or SAE ='" + model.employeename + "' or AD ='" + model.employeename + "' or SAD ='" + model.employeename + "' or yinxiaozongjian ='" + model.employeename + "' or caiwu = '" + model.employeename + "' or laoban ='" + model.employeename + "' or zhulaoban='" + model.employeename + "'");
                foreach (var item in nodes)
                {
                    projectids += ("," + item.projectid);
                }
                ViewBag.choosecount = count;
                ViewBag.count = Math.Ceiling(Projectbll.GetModelList("id in (" + projectids + ")").Count() / 20.00);
                var startnum = count * 20 + 1;
                var endnum = (count + 1) * 20;
                if (proname != "" && proname != null)
                {
                    string projectids2 = "0";
                    var projects = Projectbll.GetListByPage1("id in (" + projectids + ") and ProjectName like '%" + proname + "%'", "", startnum, endnum);
                    List<Project> projects1 = projects;
                    foreach (var item in projects)
                    {
                        projectids2 += ("," + item.Id);
                    }
                    projectids = projectids2;
                }

                ViewData["moneylist"] = Moneybll.GetListByPage1("ProjectId in (" + projectids + ")", "", startnum, endnum);
                ViewData["projectlist"] = Projectbll.GetListByPage1("id in (" + projectids + ")", "", startnum, endnum);

                //}

            }
            return View();
        }
        [HttpPost]
        public JsonResult indexs(string name)
        {
            if (name != "" && name != null)
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
                node nodemodel = nodebll.GetfModels(Projectmodel.Id, 3);
                node nodemodels = nodebll.GetfModels(Projectmodel.Id, 2);//paymentnode
                var catmodel = Paymentapplicationformbll.GetModelList("a.ProjectId=" + Projectmodel.Id + " and ApplyforpaymentType!=''  and a.Distinguish = 0 order by a.xuhao");
                //var catpaymentnode = Paymentnodebll.GetModelList("ProjectId="+ Projectmodel.Id);
                //查询对个人
                var personalmodel = Paymentapplicationformbll.GetModelList(" a.ProjectId=" + Projectmodel.Id + " and shuidian is null and (ApplyforpaymentType is null or ApplyforpaymentType='' )  and a.Distinguish = 2 order by a.xuhao");
                //查询对公司
                var companymodel = Paymentapplicationformbll.GetModelList("a.ProjectId=" + Projectmodel.Id + " and (ApplyforpaymentType is null or ApplyforpaymentType='') and shuidian is not null  and a.Distinguish = 3 order by a.xuhao");
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
        public ActionResult AddProject(string projectname)
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
            //根据项目名称跳转立项修改页面
            if (projectname != null)
            {
                Project promodel = Projectbll.GetModelss(projectname);
                ProjecTtype ProjecTtypemodel = ProjecTtype.GetModel(promodel.ProjecttypeId.Value);
                Company Companymodel = Companybll.GetModel(promodel.CompanyId.Value);
                Brand Brandmodel = brandbll.GetModels(Companymodel.Id);
                t_user usermodel = userbll.GetModel(promodel.userid.Value);
                Money moneymodel = Moneybll.GetModels(promodel.Id);
                projectCostlujing projectCostlujingmodel = projectCostlujingbll.GetModels(promodel.Id);//报价表
                ProjectQuotationlujing ProjectQuotationlujingmodel = ProjectQuotationlujingbll.GetModels(promodel.Id);//成本表
                ViewBag.projectname = projectname;//项目名称
                ViewBag.ProjectCode = promodel.ProjectCode;//项目代码
                ViewBag.ProjecTtypeName = ProjecTtypemodel.Name; //项目内别
                ViewBag.CompanyName = Companymodel.Name; //集团名称
                ViewBag.BranName = Brandmodel.Name;//品牌名称
                ViewBag.PurchaseSingleCode = promodel.PurchaseSingleCode; //采购单码(PO)
                ViewBag.UserName = usermodel.employeename; //项目负责人

                ViewBag.ProjectStartDate = promodel.ProjectStartDate;//开始时间
                ViewBag.ProjectEndDate = promodel.ProjectEndDate;//结束时间
                ViewBag.TotalMoney = moneymodel.TotalMoney;//非税金额
                ViewBag.NoTaxlMoney = moneymodel.NoTaxlMoney;//含税金额
                ViewBag.projectcost = moneymodel.projectcost;//项目成本
                ViewBag.projectCostlujing = projectCostlujingmodel.projectCostUrl;//报价
                ViewBag.ProjectQuotationlujing = ProjectQuotationlujingmodel.ProjectQuotationUrl;//成本
                ViewBag.jindu = promodel.Planprogress;//计划进度
                ViewBag.beizhu = promodel.Remarks;//备注
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
        //修改立项表给项目成员弹出层绑值
        [HttpPost]
        public JsonResult jsonAddProject(string projectname)
        {
            Project promodel = Projectbll.GetModelss(projectname);
            node nodesmodel = nodebll.GetfModels(promodel.Id, 1);
            return Json(nodesmodel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddProjects(string name, string core, string sele, string companyname, string pingpai, string core2, string xiangmuuser, string date, string date2, string Totalmoney, string Notaxmoney, string cost, string jingdu, string beizhu, string usname, string porjectname, string ae, string sae, string ad, string sad, string yingxiao, string caiwu, string laoban, string zhulaoban, string processstate)
        {
            string msg = AddProjectss(name, core, sele, companyname, pingpai, core2, xiangmuuser, date, date2, Totalmoney, Notaxmoney, cost, jingdu, beizhu, usname, porjectname, ae, sae, ad, sad, yingxiao, caiwu, laoban, zhulaoban, processstate);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult projectCostlujing(string porjectname)
        {
            var bianliang = System.Web.HttpContext.Current;
            bianliang.Response.ContentType = "text/plain";
            HttpPostedFile filePost = bianliang.Request.Files["filed"]; // 获取上传的文件  
            string filePath = SaveExcelFile(filePost); // 保存文件并获取文件路径
            Model.projectCostlujing projectCostlujingmodel = new Model.projectCostlujing();
            Bll.projectCostlujing bll = new Bll.projectCostlujing();
            //修改文件
            if (filePath != "")
            {
                if (porjectname != "")
                {
                    Project model1 = Projectbll.GetModelss(porjectname);
                    projectCostlujing projectCostlujingmodel1 = bll.GetModels(model1.Id);
                    projectCostlujingmodel1.projectCostUrl = filePath;
                    bll.Update(projectCostlujingmodel1);
                }
                else
                {
                    projectCostlujingmodel.projectCostUrl = filePath;
                    projectCostlujingmodel.ProjectId = Convert.ToInt32(model1);
                    bll.Add(projectCostlujingmodel);
                }
            }
            return Json(filePath, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ProjectQuotationlujing(string porjectname)
        {
            var bianliang1 = System.Web.HttpContext.Current;
            bianliang1.Response.ContentType = "text/plain";
            HttpPostedFile filePost1 = bianliang1.Request.Files["filed1"]; // 获取上传的文件  
            string filePath1 = SaveExcelFile(filePost1);
            if (filePath1 != "")
            {
                // 保存文件并获取文件路径
                Model.ProjectQuotationlujing ProjectQuotationlujingmodel = new Model.ProjectQuotationlujing();
                Bll.ProjectQuotationlujing bll = new Bll.ProjectQuotationlujing();
                //修改文件
                if (porjectname != "")
                {
                    Project model1 = Projectbll.GetModelss(porjectname);
                    ProjectQuotationlujing projectCostlujingmodel1 = bll.GetModels(model1.Id);
                    projectCostlujingmodel1.ProjectQuotationUrl = filePath1;
                    bll.Update(projectCostlujingmodel1);
                }
                else
                {
                    ProjectQuotationlujingmodel.ProjectQuotationUrl = filePath1;
                    ProjectQuotationlujingmodel.ProjectId = Convert.ToInt32(model1);
                    bll.Add(ProjectQuotationlujingmodel);
                }

            }

            return Json(filePath1, JsonRequestBehavior.AllowGet);
        }
        public static int model1;
        private string AddProjectss(string name, string core, string sele, string companyname, string pingpai, string core2, string xiangmuuser, string date, string date2, string Totalmoney, string Notaxmoney, string cost, string jingdu, string beizhu, string usname, string porjectname, string ae, string sae, string ad, string sad, string yingxiao, string caiwu, string laoban, string zhulaoban, string processstate)
        {
            Model.Project model = new Model.Project();
            Model.ProjecTtype Ttypemodel = new Model.ProjecTtype();
            Model.Company Companymodel = new Model.Company();
            Model.Brand Brandmodel = new Model.Brand();
            Model.Money Moneymodel = new Model.Money();
            Bll.node nodebll = new Bll.node();
            node nodemodel1 = new node();
            if (name != null && core != null && sele != null && companyname != null && pingpai != null && core2 != null && xiangmuuser != null && date != null && date2 != null && Totalmoney != null && Notaxmoney != null && cost != null)
            {
                if (porjectname == "")
                {
                    //反序列化AE人员
                    JavaScriptSerializer jsonSerialzer = new JavaScriptSerializer();
                    string[] retObj = jsonSerialzer.Deserialize<string[]>(ae);
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < retObj.Length; i++)
                    {
                        str.Append(retObj[i] + ",");
                    }
                    Ttypemodel.Name = sele; //项目类型
                    Ttypemodel.USName = usname;
                    Companymodel.Name = companyname;//公司名称
                    Brandmodel.Name = pingpai;//品牌名称
                    var ProjecTtypes = 0;
                    if (Ttypemodel.Name != null)
                    {
                        ProjecTtypes = ProjecTtype.Add(Ttypemodel);
                    }
                    //添加公司表
                    var Companymodels = 0;
                    if (Companymodel.Name != null)
                    {
                        Companymodels = Companybll.Add(Companymodel);
                    }
                    //添加品牌表
                    if (Brandmodel.Name != null)
                    {
                        Brandmodel.CompanyId = Companymodels;
                        brandbll.Add(Brandmodel);
                    }

                    Model.t_user usermodel = userbll.GetModelsss(xiangmuuser);
                    model.ProjectName = name; //项目名称
                    model.ProjectCode = core; //项目代码
                    model.PurchaseSingleCode = core2;//采购单码

                    model.ProjectStartDate = Convert.ToDateTime(date);//开始时间
                    model.ProjectEndDate = Convert.ToDateTime(date2);//结束时间
                    model.CompanyId = Companymodels;
                    model.ProjecttypeId = ProjecTtypes;
                    if (usermodel != null)
                    {
                        model.userid = usermodel.id;//项目负责人
                    }
                    model.Remarks = beizhu; //备注
                    model.Planprogress = jingdu; //计划进度
                    //获取最新的自增ID
                    model1 = Projectbll.Add(model);
                    Moneymodel.projectcost = Convert.ToDecimal(cost); //项目成本
                    Moneymodel.TotalMoney = Convert.ToDecimal(Totalmoney);//非税金额
                    Moneymodel.NoTaxlMoney = Convert.ToDecimal(Notaxmoney);//含税金额
                    Moneymodel.ProjectId = Convert.ToInt32(model1); //项目id
                    if (Moneymodel != null)
                    {
                        Moneybll.Add(Moneymodel);
                    }

                    nodemodel1.projectid = Convert.ToInt32(model1);
                    nodemodel1.AE = str.ToString();
                    nodemodel1.SAE = sae;
                    nodemodel1.AD = ad;
                    nodemodel1.SAD = sad;
                    nodemodel1.yinxiaozongjian = yingxiao;
                    nodemodel1.caiwu = caiwu;
                    nodemodel1.laoban = laoban;
                    nodemodel1.zhulaoban = zhulaoban;
                    nodemodel1.Stateofapproval = 1;
                    //插入三条数据
                    nodemodel1.processstate = Convert.ToInt32(processstate);
                    nodebll.Add(nodemodel1);
                    nodemodel1.processstate = Convert.ToInt32(processstate) + 2;
                    nodebll.Add(nodemodel1);


                    return "{\"status\": 1,\"msg\":\"申请成功！\"}";
                }
                else if (porjectname != "")
                {
                    Project model1 = Projectbll.GetModelss(porjectname);
                    ProjecTtype Ttypemodel1 = ProjecTtype.GetModel(model1.ProjecttypeId.Value);
                    Company companymodel1 = companybll.GetModel(model1.CompanyId.Value);
                    Brand brandmodel1 = brandbll.GetModels(companymodel1.Id);
                    Money Moneymodel1 = Moneybll.GetModels(model1.Id);
                    Ttypemodel1.Name = sele; //项目类型
                    Ttypemodel1.USName = usname;
                    companymodel1.Name = companyname;//公司名称
                    brandmodel1.Name = pingpai;//品牌名称
                    ProjecTtype.Update(Ttypemodel1);
                    Companybll.Update(companymodel1);
                    brandbll.Update(brandmodel1);
                    Model.t_user usermodel = userbll.GetModelsss(xiangmuuser);
                    model1.ProjectName = name; //项目名称
                    model1.ProjectCode = core; //项目代码
                    model1.PurchaseSingleCode = core2;//采购单码
                    model1.ProjectStartDate = Convert.ToDateTime(date);//开始时间
                    model1.ProjectEndDate = Convert.ToDateTime(date2);//结束时间
                    //model1.CompanyId = Companymodel.Id;
                    //Ttypemodel = ProjecTtype.GetModels();
                    //model1.ProjecttypeId = Ttypemodel.Id;
                    if (usermodel != null)
                    {
                        model1.userid = usermodel.id;//项目负责人
                    }
                    model1.Remarks = beizhu; //备注
                    model1.Planprogress = jingdu; //计划进度
                    Projectbll.Update(model1);
                    Moneymodel1.projectcost = Convert.ToDecimal(cost); //项目成本
                    Moneymodel1.TotalMoney = Convert.ToDecimal(Totalmoney);//非税金额
                    Moneymodel1.NoTaxlMoney = Convert.ToDecimal(Notaxmoney);//含税金额
                    Moneybll.Update(Moneymodel1);
                    //审批人修改后默认当前审批人已审批2018年9月13日12:05:02
                    node nodemodel = nodebll.GetfModels(model1.Id, 1);
                    Model.t_user getusermodel = GetUserInfo();
                    Project projectmodel = Projectbll.GetModelss(porjectname);
                    if (model != null)
                    {
                        if (nodemodel.Stateofapproval == 0)
                        {
                            nodemodel.Stateofapproval = 1;
                            nodebll.Update(nodemodel);
                            return "{\"status\": 1,\"msg\":\"修改成功，且项目负责人审批成功!\"}";
                        }
                        if (nodemodel.SAE == "" && nodemodel.Stateofapproval == 1)
                        {
                            nodemodel.Stateofapproval = 3;
                            nodebll.Update(nodemodel);
                        }
                        else if (nodemodel.SAE == getusermodel.employeename && nodemodel.Stateofapproval == 1)
                        {
                            nodemodel.Stateofapproval = 3;
                            //预读此审批人后的两个流程审批人，若为空，则更改流程步骤代码，以便待办事务页面获取到
                            if (nodemodel.AD == "")
                            {
                                nodemodel.Stateofapproval = 4;
                                if (nodemodel.SAD == "")
                                {
                                    nodemodel.Stateofapproval = 5;
                                }
                            }
                            nodebll.Update(nodemodel);
                            return "{\"status\": 1,\"msg\":\"修改成功，且SAE审批成功\"}";

                        }
                        if (nodemodel.AD == "" && nodemodel.Stateofapproval == 3)
                        {
                            nodemodel.Stateofapproval = 4;
                            nodebll.Update(nodemodel);
                        }
                        else if (nodemodel.AD == getusermodel.employeename && nodemodel.Stateofapproval == 3)
                        {
                            nodemodel.Stateofapproval = 4;
                            if (nodemodel.SAD == "")
                            {
                                nodemodel.Stateofapproval = 5;
                                if (nodemodel.yinxiaozongjian == "")
                                {
                                    nodemodel.Stateofapproval = 6;
                                }
                            }
                            nodebll.Update(nodemodel);
                            return "{\"status\": 1,\"msg\":\"修改成功，且AD审批成功\"}";
                        }
                        if (nodemodel.SAD == "" && nodemodel.Stateofapproval == 4)
                        {
                            nodemodel.Stateofapproval = 5;
                            nodebll.Update(nodemodel);
                        }
                        else if (nodemodel.SAD == getusermodel.employeename && nodemodel.Stateofapproval == 4)
                        {
                            nodemodel.Stateofapproval = 5;
                            if (nodemodel.yinxiaozongjian == "")
                            {
                                nodemodel.Stateofapproval = 6;
                                if (nodemodel.caiwu == "")
                                {
                                    nodemodel.Stateofapproval = 8;
                                }
                            }
                            nodebll.Update(nodemodel);
                            return "{\"status\": 1,\"msg\":\"修改成功，且SAD审批成功\"}";
                        }
                        if (nodemodel.yinxiaozongjian == "" && nodemodel.Stateofapproval == 5)
                        {
                            nodemodel.Stateofapproval = 6;
                            nodebll.Update(nodemodel);
                        }
                        else if (nodemodel.yinxiaozongjian == getusermodel.employeename && nodemodel.Stateofapproval == 5)
                        {
                            nodemodel.Stateofapproval = 6;
                            if (nodemodel.caiwu == "")
                            {
                                nodemodel.Stateofapproval = 8;
                            }
                            nodebll.Update(nodemodel);
                            return "{\"status\": 1,\"msg\":\"修改成功，且营销负责人审批成功\"}";
                        }
                        if (nodemodel.caiwu == "" && nodemodel.Stateofapproval == 6)
                        {
                            nodemodel.Stateofapproval = 8;
                            nodebll.Update(nodemodel);
                        }
                        else if (nodemodel.caiwu == getusermodel.employeename && nodemodel.Stateofapproval == 6)
                        {
                            nodemodel.Stateofapproval = 8;
                            nodebll.Update(nodemodel);
                            return "{\"status\": 1,\"msg\":\"修改成功，且财务审批成功\"}";
                        }

                        if (nodemodel.zhulaoban == getusermodel.employeename && nodemodel.Stateofapproval == 8)
                        {
                            nodemodel.Stateofapproval = 9;
                            projectmodel.caseclosed = 1;
                            Projectbll.Update(projectmodel);
                            nodebll.Update(nodemodel);
                            return "{\"status\": 1,\"msg\":\"审批成功,已立案!\"}";
                        }
                        return "{\"status\": 1,\"msg\":\"修改成功，但由于您的上一审批人未审批,或您已审批或您没有权限，未能进行审批通过操作\"}";
                    }
                    nodebll.Update(nodemodel);


                    return "{\"status\": 3,\"msg\":\"修改成功！\"}";
                }
                return "{\"status\": 2,\"msg\":\"修改失败！\"}";
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
        public JsonResult PersonalPayments(string ZFjine, string ZFdate, string shoukuanren, string kaihuhang, string Bankcode, string projectname, string Paymentobject, string xuhao, string leixing, string beizhu, string chenbenbaojia, string xiaoshoubaojia, string wangming, string chenbenbaojia2, string Distinguish, string chenbenleibie, string yongtu, string pingtai, string Applicant)
        {
            string msg = PersonalPaymentss(ZFjine, ZFdate, shoukuanren, kaihuhang, Bankcode, projectname, Paymentobject, xuhao, leixing, beizhu, chenbenbaojia, xiaoshoubaojia, wangming, chenbenbaojia2, Distinguish, chenbenleibie, yongtu, pingtai, Applicant);
            Project model = Projectbll.GetModelss(projectname);
            Model.Paymentapplicationform formmodel = Paymentapplicationformbll.GetModelsDistinguish(model.Id, xuhao, Distinguish);
            return Json(new { msg, formmodel });

        }
        private string PersonalPaymentss(string ZFjine, string ZFdate, string shoukuanren, string kaihuhang, string Bankcode, string projectname, string Paymentobject, string xuhao, string leixing, string beizhu, string chenbenbaojia, string xiaoshoubaojia, string wangming, string chenbenbaojia2, string Distinguish, string chenbenleibie, string yongtu, string pingtai, string Applican)
        {
            //数据库加一个区分字段 1,2,3 然后页面添加的时候传过来这个字段用这个字段+序号+项目ID查询，有就修改没有添加，不用管是A还是B还是C，
            //页面绑定数据加隐藏域获取区分字段以便于修改能定位到该数据
            Model.Paymentapplicationform Paymentapplicationmodel = new Paymentapplicationform();
            Model.Paymentnode Paymentnodemodel = new Paymentnode();
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
                    if (wangming != "" && wangming != null)
                    {
                        Paymentapplicationmodel.wangming = wangming;
                    }
                    Paymentapplicationmodel.Costcategory = chenbenleibie;
                    Paymentapplicationmodel.purpose = yongtu;
                    Paymentapplicationmodel.Distinguish = Convert.ToInt32(Distinguish);
                    Paymentapplicationmodel.pingtai = pingtai;
                    Paymentapplicationmodel.Applicant = Applican;
                    //李：判定当前实际付款金额，若为空，则为实际付款与含税成本合计赋上初始值
                    if (Paymentapplicationmodel.Financialcost == null)
                    {
                        Paymentapplicationmodel.Financialcost = 0;
                        Paymentapplicationmodel.Totaltaxcost = Convert.ToDecimal(ZFjine);
                    }
                    //保存付款审批流程表的数据
                    Paymentnodemodel.projectId = model.Id;
                    Paymentnodemodel.xuhao = Convert.ToInt32(xuhao);
                    Paymentnodemodel.Distinguish = Convert.ToInt32(Distinguish);
                    Paymentnodemodel.Stateofapproval = 1;
                    //获取项目审批人员并且保存到数据库
                    node nodemodel = nodebll.GetModels(model.Id);
                    Paymentnodemodel.SAE = nodemodel.SAE;
                    Paymentnodemodel.AD = nodemodel.AD;
                    Paymentnodemodel.SAD = nodemodel.SAD;
                    Paymentnodemodel.yinxiaozongjian = nodemodel.yinxiaozongjian;
                    Paymentnodemodel.caiwu = nodemodel.caiwu;
                    Paymentnodemodel.laoban = nodemodel.laoban;
                    Paymentnodemodel.zhulaoban = nodemodel.zhulaoban;
                    Paymentnodebll.Add(Paymentnodemodel);
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
                cationmodel.Actualamountofpayment = Convert.ToDecimal(ZFjine);//应支付金额
                cationmodel.CostQuotation = Convert.ToDecimal(chenbenbaojia);//成本报价
                cationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia);//销售报价
                //if (caiwuchengben != null&& caiwuchengben != "")
                //{
                //    cationmodel.Financialcost = Convert.ToDecimal(caiwuchengben);//财务成本
                //}
                if (chenbenbaojia2 != "" && chenbenbaojia2 != null)
                {
                    cationmodel.Financialcost = Convert.ToDecimal(chenbenbaojia2);//财务成本2
                }
                else {
                    cationmodel.Financialcost = 0;
                }
                //李：更改实际付款金额时也把含税成本合计更改掉
                cationmodel.Totaltaxcost = cationmodel.Financialcost + cationmodel.Actualamountofpayment;
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
        public JsonResult PaymentCompanys(string ZFjine, string fapiao, string fapiaosuie, string ZFdate, string gsname, string kaihuhang, string Bankcode, string projectname, string Paymentobject, string xuhao, string leixing, string beizhu, string suidian, string chenbenbaojia, string xiaoshoubaojia, string wangming, string chenbenbaojia2, string Distinguish, string chenbenleibie, string yongtu, string pingtai, string Applicant)
        {
            string msg = PaymentCompanyss(ZFjine, fapiao, fapiaosuie, ZFdate, gsname, kaihuhang, Bankcode, projectname, Paymentobject, xuhao, leixing, beizhu, suidian, chenbenbaojia, xiaoshoubaojia, wangming, chenbenbaojia2, Distinguish, chenbenleibie, yongtu, pingtai, Applicant);
            Project model = Projectbll.GetModelss(projectname);
            Model.Paymentapplicationform formmodel = Paymentapplicationformbll.GetModelsDistinguish(model.Id, xuhao, Distinguish);
            return Json(new { msg, formmodel });
            // return Json(msg, formmodel, JsonRequestBehavior.AllowGet);

        }
        private string PaymentCompanyss(string ZFjine, string fapiao, string fapiaosuie, string ZFdate, string gsname, string kaihuhang, string Bankcode, string projectname, string Paymentobject, string xuhao, string leixing, string beizhu, string suidian, string chenbenbaojia, string xiaoshoubaojia, string wangming, string chenbenbaojia2, string Distinguish, string chenbenleibie, string yongtu, string pingtai, string Applicant)
        {
            Model.Paymentapplicationform Paymentapplicationmodel = new Paymentapplicationform();
            Model.Paymentnode Paymentnodemodel = new Paymentnode();
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
                    Paymentapplicationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia);//销售报价
                    //Paymentapplicationmodel.Financialcost= Convert.ToDecimal(caiwuchengben);//财务成本
                    Paymentapplicationmodel.shuidian = Convert.ToDecimal(suidian);//税点
                    Paymentapplicationmodel.pingtai = pingtai;
                    Paymentapplicationmodel.Applicant = Applicant;
                    if (wangming != "" && wangming != null)
                    {
                        Paymentapplicationmodel.wangming = wangming;
                    }
                    //李：判定当前实际付款金额，若为空，则为实际付款与含税成本合计赋上初始值
                    if (Paymentapplicationmodel.Financialcost == null)
                    {
                        Paymentapplicationmodel.Financialcost = 0;
                        Paymentapplicationmodel.Totaltaxcost = Convert.ToDecimal(ZFjine);
                    }
                    Paymentapplicationmodel.Costcategory = chenbenleibie;
                    Paymentapplicationmodel.purpose = yongtu;
                    Paymentapplicationmodel.Distinguish = Convert.ToInt32(Distinguish);
                    //保存付款审批流程表的数据
                    Paymentnodemodel.projectId = model.Id;
                    Paymentnodemodel.xuhao = Convert.ToInt32(xuhao);
                    Paymentnodemodel.Distinguish = Convert.ToInt32(Distinguish);
                    Paymentnodemodel.Stateofapproval = 1;
                    //获取项目审批人员并且保存到数据库
                    node nodemodel = nodebll.GetModels(model.Id);
                    Paymentnodemodel.SAE = nodemodel.SAE;
                    Paymentnodemodel.AD = nodemodel.AD;
                    Paymentnodemodel.SAD = nodemodel.SAD;
                    Paymentnodemodel.yinxiaozongjian = nodemodel.yinxiaozongjian;
                    Paymentnodemodel.caiwu = nodemodel.caiwu;
                    Paymentnodemodel.laoban = nodemodel.laoban;
                    Paymentnodemodel.zhulaoban = nodemodel.zhulaoban;
                    Paymentnodebll.Add(Paymentnodemodel);
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
                cationmodel.CostQuotation = Convert.ToDecimal(chenbenbaojia);//成本报价
                cationmodel.Salesquotation = Convert.ToDecimal(xiaoshoubaojia);//销售报价
                //if (caiwuchengben != null)
                //{
                //    cationmodel.Financialcost = Convert.ToDecimal(caiwuchengben);//财务成本
                //}
                if (chenbenbaojia2 != "" && chenbenbaojia2 != null)
                {
                    cationmodel.Financialcost = Convert.ToDecimal(chenbenbaojia2);//财务成本2
                }
                //李：更改实际付款金额时也把含税成本合计更改掉
                cationmodel.Totaltaxcost = cationmodel.Financialcost + cationmodel.Actualamountofpayment;
                cationmodel.shuidian = Convert.ToDecimal(suidian);//税点
                cationmodel.wangming = wangming;
                cationmodel.Distinguish = Convert.ToInt32(Distinguish);
                cationmodel.Costcategory = chenbenleibie;
                cationmodel.purpose = yongtu;
                cationmodel.pingtai = pingtai;
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
        public JsonResult updateview(string xuhao, string projectname, string Distinguish)
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
        public JsonResult mixibaocun(string beizu, string xsbjhj, string sjhj, string Noheji, string heji, string maolirun, string Nozhifu, string yuangongjiangjin, string weifenpeilirun, string lirunbaifenbi, string prijectname, string Expectedreturndate, string Actualdate, string daozhangjine, string AMargemBrutapercentual, string Olucrolíquido, string Aporcentagemdelucrolíquido)
        {
            string msg = mixibaocuns(beizu, xsbjhj, sjhj, Noheji, heji, maolirun, Nozhifu, yuangongjiangjin, weifenpeilirun, lirunbaifenbi, prijectname, Expectedreturndate, Actualdate, daozhangjine, AMargemBrutapercentual, Olucrolíquido, Aporcentagemdelucrolíquido);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string mixibaocuns(string beizu, string xsbjhj, string sjhj, string Noheji, string heji, string maolirun, string Nozhifu, string yuangongjiangjin, string weifenpeilirun, string lirunbaifenbi, string prijectname, string Expectedreturndate, string Actualdate, string daozhangjine, string AMargemBrutapercentual, string Olucrolíquido, string Aporcentagemdelucrolíquido)
        {
            Project promodel = Projectbll.GetModelss(prijectname);
            Money moneymodel = Moneybll.GetModels(promodel.Id);
            // Model.Paymentapplicationform cationmodel = Paymentapplicationformbll.GetModels(promodel.Id, xuhao);
            if (promodel != null)
            {
                promodel.Remarks = beizu;
                promodel.Expectedreturndate = Convert.ToDateTime(Expectedreturndate);
                //修改于2018年9月14日17:54:55
                if (Actualdate != "")
                {
                    promodel.Actualdate = Convert.ToDateTime(Actualdate);
                }
                //2018年9月14日17:47:26
                //promodel.POdanhao = po;
                //修改于2018年9月14日17:55:13
                if (daozhangjine != "")
                {
                    promodel.Accountamount = Convert.ToDecimal(daozhangjine);
                }
                Projectbll.Update(promodel);
            }
            if (moneymodel != null)
            {
                if (xsbjhj != "")
                {
                    moneymodel.SalesQuotations = Convert.ToDecimal(xsbjhj);//销售报价合计
                }
                if (sjhj != null && sjhj != "")
                {
                    moneymodel.TaxSum = Convert.ToDecimal(sjhj);//税金合计
                }
                moneymodel.NonTaxCostCombined = Convert.ToDecimal(Noheji); //不含税成本合计
                if (heji != null && heji != "")
                {
                    moneymodel.Totaltaxcosttow = Convert.ToDecimal(heji);//含税成本合计
                }
                moneymodel.Grossprofit = Convert.ToDecimal(maolirun);//毛利润
                if (Nozhifu != "")
                {
                    moneymodel.Unpaidchannel = Convert.ToDecimal(Nozhifu); //未支付渠道款
                }
                if (yuangongjiangjin != "")
                {
                    moneymodel.Employeebonus = Convert.ToDecimal(yuangongjiangjin);//员工奖金
                }
                if (weifenpeilirun != "")
                {
                    moneymodel.Undistributedprofit = Convert.ToDecimal(weifenpeilirun);//未分配利润
                }
                moneymodel.Percentageofprofit = lirunbaifenbi;//利润百分比
                moneymodel.AMargemBrutapercentual = AMargemBrutapercentual;
                if (Olucrolíquido != "")
                {
                    moneymodel.Olucrolíquido = Convert.ToDecimal(Olucrolíquido);
                }
                if (Aporcentagemdelucrolíquido != "")
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
        public JsonResult shenpi(string projectname, string processstate, string xuhao, string Distinguish)
        {
            string msg = shenpis(projectname, processstate, xuhao, Distinguish);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string shenpis(string projectname, string processstate, string xuhao, string Distinguish)
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
            if (processstate == "2" && formmodel.readState == 1)
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
                if (model.SAE == "" && model.Stateofapproval == 1)
                {
                    model.Stateofapproval = 3;
                    nodebll.Update(model);
                }
                else if (model.SAE == usermodel.employeename && model.Stateofapproval == 1)
                {
                    model.Stateofapproval = 3;
                    //预读此审批人后的两个流程审批人，若为空，则更改流程步骤代码，以便待办事务页面获取到
                    if (model.AD == "")
                    {
                        model.Stateofapproval = 4;
                        if (model.SAD == "")
                        {
                            model.Stateofapproval = 5;
                        }
                    }
                    nodebll.Update(model);
                    return "{\"status\": 3,\"msg\":\"SAE审批成功\"}";

                }
                if (model.AD == "" && model.Stateofapproval == 3)
                {
                    model.Stateofapproval = 4;
                    nodebll.Update(model);
                }
                else if (model.AD == usermodel.employeename && model.Stateofapproval == 3)
                {
                    model.Stateofapproval = 4;
                    if (model.SAD == "")
                    {
                        model.Stateofapproval = 5;
                        if (model.yinxiaozongjian == "")
                        {
                            model.Stateofapproval = 6;
                        }
                    }
                    nodebll.Update(model);
                    return "{\"status\": 4,\"msg\":\"AD审批成功\"}";
                }
                if (model.SAD == "" && model.Stateofapproval == 4)
                {
                    model.Stateofapproval = 5;
                    nodebll.Update(model);
                }
                else if (model.SAD == usermodel.employeename && model.Stateofapproval == 4)
                {
                    model.Stateofapproval = 5;
                    if (model.yinxiaozongjian == "")
                    {
                        model.Stateofapproval = 6;
                        if (model.caiwu == "")
                        {
                            model.Stateofapproval = 8;
                        }
                    }
                    nodebll.Update(model);
                    return "{\"status\": 5,\"msg\":\"SAD审批成功\"}";
                }
                if (model.yinxiaozongjian == "" && model.Stateofapproval == 5)
                {
                    model.Stateofapproval = 6;
                    nodebll.Update(model);
                }
                else if (model.yinxiaozongjian == usermodel.employeename && model.Stateofapproval == 5)
                {
                    model.Stateofapproval = 6;
                    if (model.caiwu == "")
                    {
                        model.Stateofapproval = 8;
                    }
                    nodebll.Update(model);
                    return "{\"status\": 6,\"msg\":\"营销负责人审批成功\"}";
                }
                if (model.caiwu == "" && model.Stateofapproval == 6)
                {
                    model.Stateofapproval = 7;
                    nodebll.Update(model);
                }
                else if (model.caiwu == usermodel.employeename && model.Stateofapproval == 6)
                {
                    if (processstate == "1")
                    {
                        model.Stateofapproval = 8;
                        nodebll.Update(model);
                        return "{\"status\": 8,\"msg\":\"财务审批成功\"}";
                    }
                    else
                    {
                        model.Stateofapproval = 7;
                        nodebll.Update(model);
                        return "{\"status\": 7,\"msg\":\"财务审批成功\"}";
                    }
                       
                }
                if (model.laoban == usermodel.employeename && model.Stateofapproval == 7)
                {
                    model.Stateofapproval = 8;
                    nodebll.Update(model);
                    return "{\"status\": 8,\"msg\":\"老板审批成功\"}";
                }
                if (model.zhulaoban == usermodel.employeename && model.Stateofapproval == 8)
                {
                    if (processstate == "2")
                    {
                        model.Stateofapproval = 0;
                        formmodel.readState = 1;
                        Paymentapplicationformbll.Update(formmodel);
                        nodebll.Update(model);
                        return "{\"status\":15,\"msg\":\"当前付款,审批成功!\"}";
                    }
                    else if (processstate == "3")
                    {
                        model.Stateofapproval = 9;
                        projectmodel.typefinished = 1;
                        Projectbll.Update(projectmodel);
                        nodebll.Update(model);
                        return "{\"status\": 9,\"msg\":\"审批成功,已结案!\"}";
                    }
                    else if (processstate == "1")
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



        //付款审批
        [HttpPost]
        public JsonResult paymentshenpi(string projectname, string xuhao, string Distinguish)
        {
            string msg = paymentshenpis(projectname, xuhao, Distinguish);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string paymentshenpis(string projectname, string xuhao, string Distinguish)
        {
            Project projectmodel = Projectbll.GetModelss(projectname);
            Paymentapplicationform formmodel = Paymentapplicationformbll.GetModelsDistinguish(projectmodel.Id, xuhao, Distinguish);
            Model.t_user usermodel = GetUserInfo();
            Model.t_user usermodel1 = userbll.GetModel(projectmodel.userid.Value);
            Bll.Paymentnode nodebll = new Bll.Paymentnode();
            Paymentnode model = new Paymentnode();
            model = nodebll.GetModels(projectmodel.Id, Convert.ToInt32(xuhao), Convert.ToInt32(Distinguish));
            model.Rejection = "";
            if (formmodel.readState == 1)
            {
                return "{\"status\": 0,\"msg\":\"审批已通过!\"}";
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
                if (model.SAE == "" && model.Stateofapproval == 1)
                {
                    model.Stateofapproval = 3;
                    nodebll.Update(model);
                }
                else if (model.SAE == usermodel.employeename && model.Stateofapproval == 1)
                {
                    model.Stateofapproval = 3;
                    //预读此审批人后的两个流程审批人，若为空，则更改流程步骤代码，以便待办事务页面获取到
                    if (model.AD == "")
                    {
                        model.Stateofapproval = 4;
                        if (model.SAD == "")
                        {
                            model.Stateofapproval = 5;
                        }
                    }
                    nodebll.Update(model);
                    return "{\"status\": 3,\"msg\":\"SAE审批成功\"}";

                }
                if (model.AD == "" && model.Stateofapproval == 3)
                {
                    model.Stateofapproval = 4;
                    nodebll.Update(model);
                }
                else if (model.AD == usermodel.employeename && model.Stateofapproval == 3)
                {
                    model.Stateofapproval = 4;
                    if (model.SAD == "")
                    {
                        model.Stateofapproval = 5;
                        if (model.yinxiaozongjian == "")
                        {
                            model.Stateofapproval = 6;
                        }
                    }
                    nodebll.Update(model);
                    return "{\"status\": 4,\"msg\":\"AD审批成功\"}";
                }
                if (model.SAD == "" && model.Stateofapproval == 4)
                {
                    model.Stateofapproval = 5;
                    nodebll.Update(model);
                }
                else if (model.SAD == usermodel.employeename && model.Stateofapproval == 4)
                {
                    model.Stateofapproval = 5;
                    if (model.yinxiaozongjian == "")
                    {
                        model.Stateofapproval = 6;
                        if (model.caiwu == "")
                        {
                            model.Stateofapproval = 8;
                        }
                    }
                    nodebll.Update(model);
                    return "{\"status\": 5,\"msg\":\"SAD审批成功\"}";
                }
                if (model.yinxiaozongjian == "" && model.Stateofapproval == 5)
                {
                    model.Stateofapproval = 6;
                    nodebll.Update(model);
                }
                else if (model.yinxiaozongjian == usermodel.employeename && model.Stateofapproval == 5)
                {
                    model.Stateofapproval = 6;
                    if (model.caiwu == "")
                    {
                        model.Stateofapproval = 8;
                    }
                    nodebll.Update(model);
                    return "{\"status\": 6,\"msg\":\"营销负责人审批成功\"}";
                }
                if (model.caiwu == "" && model.Stateofapproval == 6)
                {
                    model.Stateofapproval = 8;
                    nodebll.Update(model);
                }
                else if (model.caiwu == usermodel.employeename && model.Stateofapproval == 6)
                {
                    model.Stateofapproval = 7;
                    nodebll.Update(model);
                    return "{\"status\": 7,\"msg\":\"财务审批成功\"}";
                }
                if (model.laoban == usermodel.employeename && model.Stateofapproval == 7)
                {
                    model.Stateofapproval = 8;
                    nodebll.Update(model);
                    return "{\"status\": 8,\"msg\":\"老板审批成功\"}";
                }
                if (model.zhulaoban == usermodel.employeename && model.Stateofapproval == 8)
                {
                    model.Stateofapproval = 9;
                    formmodel.readState = 1;
                    Paymentapplicationformbll.Update(formmodel);
                    nodebll.Update(model);
                    return "{\"status\":15,\"msg\":\"当前付款,审批成功!\"}";
                }
                return "{\"status\": 10,\"msg\":\"您的上一审批人未审批,或您已审批或您没有权限\"}";
            }
            else
            {
                return "{\"status\": 11,\"msg\":\"审批失败\"}";
            }
        }




        //保存当前项目的审批人
        
        //public JsonResult shenpiren(string ae, string sae, string ad, string sad, string yingxiao, string caiwu, string laoban, string zhulaoban,string processstate)
        //{
        //    string msg = shenpirens(ae, sae, ad, sad, yingxiao, caiwu, laoban, zhulaoban, processstate);
        //    return Json(msg, JsonRequestBehavior.AllowGet);
        //}
        //private string shenpirens(string ae, string sae, string ad, string sad, string yingxiao, string caiwu, string laoban, string zhulaoban,string processstate)
        //{
        //    Bll.node nodebll = new Bll.node();
        //    node model = new node();
        //    Project projectmodel = Projectbll.GetModels();
        //    t_user usermodel = GetUserInfo();
        //    //if (projectmodel.userid != usermodel.id)
        //    //{
        //    //    return "您没有权限添加当前项目的审批人!";
        //    //}
        //    if (projectmodel != null)
        //    {
        //        JavaScriptSerializer jsonSerialzer = new JavaScriptSerializer();
        //        string[] retObj = jsonSerialzer.Deserialize<string[]>(ae);
        //        StringBuilder str = new StringBuilder();
        //        for (int i = 0; i < retObj.Length; i++)
        //        {
        //            str.Append(retObj[i] + ",");
        //        }
        //        model.projectid = projectmodel.Id;
        //        model.AE = str.ToString();
        //        model.SAE = sae;
        //        model.AD = ad;
        //        model.SAD = sad;
        //        model.yinxiaozongjian = yingxiao;
        //        model.caiwu = caiwu;
        //        model.laoban = laoban;
        //        model.zhulaoban = zhulaoban;
        //        model.Stateofapproval = 1;
        //        //插入三条数据
        //        model.processstate = Convert.ToInt32(processstate);
        //        nodebll.Add(model);
        //        model.processstate = Convert.ToInt32(processstate) + 2;
        //        nodebll.Add(model);

        //        return "成功添加当前项目审批人!";
        //    }
        //    else
        //    {
        //        return "添加当前项目审批人失败!";
        //    }
        //}

    
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
        [HttpPost]
        public JsonResult checkProjectName(string projectName)
        {
            string msg = checkProjectName1(projectName);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string checkProjectName1(string projectName) {
            if (Projectbll.GetModelss(projectName) != null)
            {
                return "{\"status\": 1,\"msg\":\"消息提示:项目名称已存在，请确认后重新输入！\"}";
            }
            else {
                return "{\"status\": 0,\"msg\":\"消息提示:可使用的项目名称。\"}";
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
        [HttpPost]
        public JsonResult Paymentapprovalprocess(string projectname, string xuhao, string Distinguish)
        {
            Project projectmodel = Projectbll.GetModelss(projectname);
            Paymentnode nodemodel = Paymentnodebll.GetModels(projectmodel.Id, Convert.ToInt32(xuhao), Convert.ToInt32(Distinguish));
            //修改 2018年9月13日16:04:09
            Paymentapplicationform cationformmodel = Paymentapplicationformbll.GetModelsDistinguish(projectmodel.Id, xuhao, Distinguish);
            //修改 2018年9月13日16:04:09
            var Applicant = cationformmodel.Applicant;
            return Json(new { msg, nodemodel, Applicant });
        }
        //修改 2018年9月13日17:39:01
        [HttpPost]
        public JsonResult Rejection(string projectname, string Rejection, string xuhao, string Distinguish)
        {
            string msg = Rejections(projectname, Rejection, xuhao, Distinguish);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        private string Rejections(string projectname, string Rejection, string xuhao, string Distinguish)
        {
            t_user usermodel = GetUserInfo();
            Project promodel = Projectbll.GetModelss(projectname);
            Paymentnode model = Paymentnodebll.GetModels(promodel.Id, Convert.ToInt32(xuhao), Convert.ToInt32(Distinguish));
            model.Rejection = Rejection;
            if (model != null)
            {
                if (model.zhulaoban == usermodel.employeename && model.Stateofapproval == 8)
                {
                    model.Stateofapproval = 7;
                    Paymentnodebll.Update(model);
                    return "{\"status\":1,\"msg\":\"驳回成功!\"}";
                }
                if (model.laoban == usermodel.employeename && model.Stateofapproval == 7)
                {
                    model.Stateofapproval = 6;
                    Paymentnodebll.Update(model);
                    return "{\"status\":1,\"msg\":\"驳回成功!\"}";
                }
                if (model.caiwu == "" && model.Stateofapproval == 6)
                {
                    model.Stateofapproval = 5;
                    Paymentnodebll.Update(model);
                }
                else if (model.caiwu == usermodel.employeename && model.Stateofapproval == 6)
                {
                    model.Stateofapproval = 5;
                    Paymentnodebll.Update(model);
                    return "{\"status\":1,\"msg\":\"驳回成功!\"}";
                }
                if (model.yinxiaozongjian == "" && model.Stateofapproval == 5)
                {
                    model.Stateofapproval = 4;
                    Paymentnodebll.Update(model);
                }
                else if (model.yinxiaozongjian == usermodel.employeename && model.Stateofapproval == 5)
                {
                    model.Stateofapproval = 4;
                    if (model.SAD == "")
                    {
                        model.Stateofapproval = 3;
                        if (model.AD == "")
                        {
                            model.Stateofapproval = 1;
                        }
                    }
                    Paymentnodebll.Update(model);
                    return "{\"status\":1,\"msg\":\"驳回成功!\"}";
                }
                if (model.SAD == "" && model.Stateofapproval == 4)
                {
                    model.Stateofapproval = 3;
                    Paymentnodebll.Update(model);
                }
                else if (model.SAD == usermodel.employeename && model.Stateofapproval == 4)
                {
                    model.Stateofapproval = 3;
                    if (model.AD == "")
                    {
                        model.Stateofapproval = 1;
                    }
                    Paymentnodebll.Update(model);
                    return "{\"status\":1,\"msg\":\"驳回成功!\"}";
                }
                if (model.AD == "" && model.Stateofapproval == 3)
                {
                    model.Stateofapproval = 1;
                    Paymentnodebll.Update(model);
                }
                else if (model.AD == usermodel.employeename && model.Stateofapproval == 3)
                {
                    model.Stateofapproval = 1;
                    Paymentnodebll.Update(model);
                    return "{\"status\":1,\"msg\":\"驳回成功!\"}";
                }
                return "{\"status\": 0,\"msg\":\"上一级未审批,没有权限驳回\"}";
            }
            else
            {
                return "{\"status\": 2,\"msg\":\"驳回失败\"}";
            }
        }
    }
}