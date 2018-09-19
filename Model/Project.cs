﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <summary>
    /// Project:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Project
    {
        public Project()
        { }
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string ProjectNumber { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProjectStartDate { set; get; }   

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProjectEndDate { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Username { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectCode { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string ProjectName { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Remarks { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? OfferId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? PlatformId { set; get; }
        public int? CompanyId { set; get; }

        public int? ProjecttypeId { set; get; }

        public string PurchaseSingleCode { set; get; }
        public int? userid { set; get; }
        public string Planprogress { set; get; }

        public string POdanhao { set; get; }
        public DateTime? Expectedreturndate { set; get; }
        public DateTime? Actualdate { set; get; }
        public decimal Accountamount { set; get; }
        public int? typefinished { set; get; }
        public int? caseclosed { set; get; }
    }
}
