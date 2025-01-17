﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class NarayanBharuchEntities : DbContext
    {
        public NarayanBharuchEntities()
            : base("name=NarayanBharuchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<InnovativExperiment> InnovativExperiments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<SapanaKaroSakar> SapanaKaroSakars { get; set; }
        public DbSet<TeachersGyanstra> TeachersGyanstras { get; set; }
        public DbSet<ParsamniProject> ParsamniProjects { get; set; }
        public DbSet<LifeSkillsProject> LifeSkillsProjects { get; set; }
        public DbSet<CulturalProgram> CulturalPrograms { get; set; }
        public DbSet<StudentSubjectSeminar> StudentSubjectSeminars { get; set; }
    
        public virtual ObjectResult<GetInnovativExperimentList_Result> GetInnovativExperimentList(string search, Nullable<int> pageStart, Nullable<int> pageSize, Nullable<int> sortColumn, string sortOrder)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var pageStartParameter = pageStart.HasValue ?
                new ObjectParameter("PageStart", pageStart) :
                new ObjectParameter("PageStart", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var sortColumnParameter = sortColumn.HasValue ?
                new ObjectParameter("SortColumn", sortColumn) :
                new ObjectParameter("SortColumn", typeof(int));
    
            var sortOrderParameter = sortOrder != null ?
                new ObjectParameter("SortOrder", sortOrder) :
                new ObjectParameter("SortOrder", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetInnovativExperimentList_Result>("GetInnovativExperimentList", searchParameter, pageStartParameter, pageSizeParameter, sortColumnParameter, sortOrderParameter);
        }
    
        public virtual ObjectResult<GetSapanaKaroSakarList_Result> GetSapanaKaroSakarList(string search, Nullable<int> pageStart, Nullable<int> pageSize, Nullable<int> sortColumn, string sortOrder)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var pageStartParameter = pageStart.HasValue ?
                new ObjectParameter("PageStart", pageStart) :
                new ObjectParameter("PageStart", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var sortColumnParameter = sortColumn.HasValue ?
                new ObjectParameter("SortColumn", sortColumn) :
                new ObjectParameter("SortColumn", typeof(int));
    
            var sortOrderParameter = sortOrder != null ?
                new ObjectParameter("SortOrder", sortOrder) :
                new ObjectParameter("SortOrder", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSapanaKaroSakarList_Result>("GetSapanaKaroSakarList", searchParameter, pageStartParameter, pageSizeParameter, sortColumnParameter, sortOrderParameter);
        }
    
        public virtual ObjectResult<GetTeachersGyanstraList_Result> GetTeachersGyanstraList(string search, Nullable<int> pageStart, Nullable<int> pageSize, Nullable<int> sortColumn, string sortOrder)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var pageStartParameter = pageStart.HasValue ?
                new ObjectParameter("PageStart", pageStart) :
                new ObjectParameter("PageStart", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var sortColumnParameter = sortColumn.HasValue ?
                new ObjectParameter("SortColumn", sortColumn) :
                new ObjectParameter("SortColumn", typeof(int));
    
            var sortOrderParameter = sortOrder != null ?
                new ObjectParameter("SortOrder", sortOrder) :
                new ObjectParameter("SortOrder", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTeachersGyanstraList_Result>("GetTeachersGyanstraList", searchParameter, pageStartParameter, pageSizeParameter, sortColumnParameter, sortOrderParameter);
        }
    
        public virtual ObjectResult<GetParsamniProjectList_Result> GetParsamniProjectList(string search, Nullable<int> pageStart, Nullable<int> pageSize, Nullable<int> sortColumn, string sortOrder)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var pageStartParameter = pageStart.HasValue ?
                new ObjectParameter("PageStart", pageStart) :
                new ObjectParameter("PageStart", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var sortColumnParameter = sortColumn.HasValue ?
                new ObjectParameter("SortColumn", sortColumn) :
                new ObjectParameter("SortColumn", typeof(int));
    
            var sortOrderParameter = sortOrder != null ?
                new ObjectParameter("SortOrder", sortOrder) :
                new ObjectParameter("SortOrder", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetParsamniProjectList_Result>("GetParsamniProjectList", searchParameter, pageStartParameter, pageSizeParameter, sortColumnParameter, sortOrderParameter);
        }
    
        public virtual ObjectResult<GetLifeSkillsProjectList_Result> GetLifeSkillsProjectList(string search, Nullable<int> pageStart, Nullable<int> pageSize, Nullable<int> sortColumn, string sortOrder)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var pageStartParameter = pageStart.HasValue ?
                new ObjectParameter("PageStart", pageStart) :
                new ObjectParameter("PageStart", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var sortColumnParameter = sortColumn.HasValue ?
                new ObjectParameter("SortColumn", sortColumn) :
                new ObjectParameter("SortColumn", typeof(int));
    
            var sortOrderParameter = sortOrder != null ?
                new ObjectParameter("SortOrder", sortOrder) :
                new ObjectParameter("SortOrder", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLifeSkillsProjectList_Result>("GetLifeSkillsProjectList", searchParameter, pageStartParameter, pageSizeParameter, sortColumnParameter, sortOrderParameter);
        }
    
        public virtual ObjectResult<GetCulturalProgramList_Result> GetCulturalProgramList(string search, Nullable<int> pageStart, Nullable<int> pageSize, Nullable<int> sortColumn, string sortOrder)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var pageStartParameter = pageStart.HasValue ?
                new ObjectParameter("PageStart", pageStart) :
                new ObjectParameter("PageStart", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var sortColumnParameter = sortColumn.HasValue ?
                new ObjectParameter("SortColumn", sortColumn) :
                new ObjectParameter("SortColumn", typeof(int));
    
            var sortOrderParameter = sortOrder != null ?
                new ObjectParameter("SortOrder", sortOrder) :
                new ObjectParameter("SortOrder", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCulturalProgramList_Result>("GetCulturalProgramList", searchParameter, pageStartParameter, pageSizeParameter, sortColumnParameter, sortOrderParameter);
        }
    
        public virtual ObjectResult<GetStudentSubjectSeminarList_Result> GetStudentSubjectSeminarList(string search, Nullable<int> pageStart, Nullable<int> pageSize, Nullable<int> sortColumn, string sortOrder)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var pageStartParameter = pageStart.HasValue ?
                new ObjectParameter("PageStart", pageStart) :
                new ObjectParameter("PageStart", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            var sortColumnParameter = sortColumn.HasValue ?
                new ObjectParameter("SortColumn", sortColumn) :
                new ObjectParameter("SortColumn", typeof(int));
    
            var sortOrderParameter = sortOrder != null ?
                new ObjectParameter("SortOrder", sortOrder) :
                new ObjectParameter("SortOrder", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentSubjectSeminarList_Result>("GetStudentSubjectSeminarList", searchParameter, pageStartParameter, pageSizeParameter, sortColumnParameter, sortOrderParameter);
        }
    }
}
