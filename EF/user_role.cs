//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class user_role
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int roleid { get; set; }
    
        public virtual t_role t_role { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
