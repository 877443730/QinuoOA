using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public partial class t_user
    {
        public t_user()
        { }
        /// <summary>
        /// 
        /// </summary>
        public int id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string username { set; get; }
        public string employeename { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string pwd { set; get; }
        public string name { set; get; }
        public string pename { set; get; }
       public string adddate { set; get; }
        public string Email { set; get; }
    }
}
