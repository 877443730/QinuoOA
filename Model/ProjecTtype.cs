using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// ProjecTtype:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProjecTtype
    {
        public ProjecTtype()
        { }
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { set; get; }
        public string USName { set; get; }

    }
}
