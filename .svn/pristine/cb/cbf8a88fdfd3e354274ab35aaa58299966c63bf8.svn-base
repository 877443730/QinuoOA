using Cll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QiuoOA.Authorizers
{
    public class Uploads
    {
        public static bool DownLoadFile(string url)
        {
            var flag = false;
            try
            {
                var filePath = HttpContext.Current.Server.MapPath(url);     //获取文件的路径
                var file = new FileInfo(filePath);  //得到文件
                if (file.Exists)        //判断文件是否存在
                {
                    HttpContext.Current.Response.Clear();       //清空Response对象
                                                                /*设置浏览器请求头信息*/
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(file.Name));  //指定文件
                    HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());    //指定文件大小
                    HttpContext.Current.Response.ContentType = "application/application/octet-stream";  //指定输出方式
                    HttpContext.Current.Response.WriteFile(file.FullName);      //写出文件
                    HttpContext.Current.Response.End();         //结束Response对象
                    HttpContext.Current.Response.Flush();       //输出缓冲区(刷新Response对象)
                    HttpContext.Current.Response.Clear();       //清空Response对象

                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
    }
}