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
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.Money = new HashSet<Money>();
        }
    
        public int Id { get; set; }
        public string ProjectNumber { get; set; }
        public Nullable<System.DateTime> ProjectStartDate { get; set; }
        public Nullable<System.DateTime> ProjectEndDate { get; set; }
        public string Username { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> OfferId { get; set; }
        public Nullable<int> PlatformId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> ProjecttypeId { get; set; }
        public string PurchaseSingleCode { get; set; }
        public Nullable<int> userid { get; set; }
        public string Planprogress { get; set; }
        public string POdanhao { get; set; }
        public Nullable<System.DateTime> Expectedreturndate { get; set; }
        public Nullable<System.DateTime> Actualdate { get; set; }
        public Nullable<decimal> Accountamount { get; set; }
        public Nullable<int> typefinished { get; set; }
        public Nullable<int> caseclosed { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Money> Money { get; set; }
        public virtual OfferTable OfferTable { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual ProjecTtype ProjecTtype { get; set; }
    }
}