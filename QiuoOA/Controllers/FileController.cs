using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QiuoOA.Controllers
{
    public class FileController : Controller
    {
        Bll.Project Projectbll = new Bll.Project();
        Bll.PO pobll = new Bll.PO();
        Bll.ProjectFinalReport finalbll = new Bll.ProjectFinalReport();
        Bll.Publishlinksummary summarybll = new Bll.Publishlinksummary();
        Bll.InvoiceAttachments invoicebll = new Bll.InvoiceAttachments();
        Bll.Paymentapplicationform formbll = new Bll.Paymentapplicationform();
        // GET: File
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Fileds(string projectname)
        {
            var msg = "";
            var bianliang = System.Web.HttpContext.Current;
            bianliang.Response.ContentType = "text/plain";
            HttpPostedFile filePost = bianliang.Request.Files["filed"]; // 获取上传的文件  
            if (projectname != null)
            {
                string filePath = SaveFileds(filePost);// 保存文件并获取文件路径
                Model.Project model = Projectbll.GetModelss(projectname);
                Model.PO POgmodel = new Model.PO();
                POgmodel.POlujing = filePath;
                POgmodel.PorjectId = model.Id;
                if (POgmodel != null)
                {
                    pobll.Add(POgmodel);
                }
                var lujing = POgmodel.POlujing;
                return Json(lujing, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(msg = "上传失败请选择项目!", JsonRequestBehavior.AllowGet);
            }
        }

        private string SaveFileds(HttpPostedFile file)
        {

            try
            {
                var bianliang = System.Web.HttpContext.Current.Server.MapPath("~/PO");
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

        [HttpPost]
        public JsonResult Fileds1(string projectname)
        {
            var msg = "";
            var bianliang = System.Web.HttpContext.Current;
            bianliang.Response.ContentType = "text/plain";
            HttpPostedFile filePost = bianliang.Request.Files["filed1"]; // 获取上传的文件  
            if (projectname != null)
            {
                string filePath = SaveFileds1(filePost);// 保存文件并获取文件路径
                Model.Project model = Projectbll.GetModelss(projectname);
                Model.ProjectFinalReport Reportgmodel = new Model.ProjectFinalReport();
                Reportgmodel.Reportlujing = filePath;
                Reportgmodel.ProjectId = model.Id;
                if (Reportgmodel != null)
                {
                    finalbll.Add(Reportgmodel);
                }
                return Json(filePath, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(msg = "上传失败请选择项目!", JsonRequestBehavior.AllowGet);
            }
        }

        private string SaveFileds1(HttpPostedFile file)
        {

            try
            {
                var bianliang = System.Web.HttpContext.Current.Server.MapPath("~/Report");
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

        [HttpPost]
        public JsonResult Fileds2(string projectname)
        {
            var msg = "";
            var bianliang = System.Web.HttpContext.Current;
            bianliang.Response.ContentType = "text/plain";
            HttpPostedFile filePost = bianliang.Request.Files["filed2"]; // 获取上传的文件  
            if (projectname != null)
            {
                string filePath = SaveFileds2(filePost);// 保存文件并获取文件路径
                Model.Project model = Projectbll.GetModelss(projectname);
                Model.Publishlinksummary summarymodel = new Model.Publishlinksummary();
                summarymodel.summarylujing = filePath;
                summarymodel.ProjectId = model.Id;
                if (summarymodel != null)
                {
                    summarybll.Add(summarymodel);
                }
                return Json(filePath, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(msg = "上传失败请选择项目!", JsonRequestBehavior.AllowGet);
            }
        }

        private string SaveFileds2(HttpPostedFile file)
        {

            try
            {
                var bianliang = System.Web.HttpContext.Current.Server.MapPath("~/summary");
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

        //发票附件
        [HttpPost]
        public JsonResult Fileds3()
        {
            var msg = "";
            var bianliang = System.Web.HttpContext.Current;
            bianliang.Response.ContentType = "text/plain";
            HttpPostedFile filePost = bianliang.Request.Files["fileds"]; // 获取上传的文件  

            string filePath = SaveFileds3(filePost);// 保存文件并获取文件路径
            Model.Paymentapplicationform formmodel = formbll.GetModelsss();
            if (formmodel != null)
            {
                Model.InvoiceAttachments invoicemodel = new Model.InvoiceAttachments();
                invoicemodel.Invoiceurl = filePath;
                invoicemodel.PaymentapplicationformId = formmodel.Id;
                if (invoicemodel != null)
                {
                    invoicebll.Add(invoicemodel);
                }
                return Json(filePath, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(msg = "上传失败请选择项目!", JsonRequestBehavior.AllowGet);
            }
        }

        private string SaveFileds3(HttpPostedFile file)
        {

            try
            {
                var bianliang = System.Web.HttpContext.Current.Server.MapPath("~/Invoice");
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
    }
}