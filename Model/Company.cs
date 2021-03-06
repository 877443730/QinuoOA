﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Company:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Company
    {
        public Company()
        { }
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 
        /// </summary>

        public string phone { set; get; }
        public string Contact { set; get; }
        public string mail { set; get; }
        public string Remarks { set; get; }
        public string code { set; get; }
    }
}
