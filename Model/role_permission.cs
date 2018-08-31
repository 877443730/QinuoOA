using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
	/// role_permission:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class role_permission
    {
        public role_permission()
        { }
        /// <summary>
        /// 
        /// </summary>
        public int id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int roleid { set; get; }
  
        /// <summary>
        /// 
        /// </summary>
        public int permissionid { set; get; }
       

    }
}
