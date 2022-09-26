using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NarayanBharuch.Areas.Admin.Models.AdminModel
{
    public abstract class BaseEntityModel
    {
        public long Id { get; set; }
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public System.DateTime EventDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime? ModifiedOn { get; set; }
        public string Department { get; set; }
        public string Photos { get; set; }
        public int? TotalRows { get; set; }
    }
}