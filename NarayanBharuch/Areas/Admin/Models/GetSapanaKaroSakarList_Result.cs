//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NarayanBharuch.Areas.Admin.Models
{
    using System;
    
    public partial class GetSapanaKaroSakarList_Result
    {
        public Nullable<long> RowNum { get; set; }
        public Nullable<int> TotalRows { get; set; }
        public long Id { get; set; }
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public System.DateTime EventDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string Department { get; set; }
    }
}
