using NarayanBharuch.Areas.Admin.Models.AdminModel;
namespace NarayanBharuch.Areas.Admin.Models.Extention
{
    public static class StudentSubjectSeminarExtention
    {
        public static StudentSubjectSeminarModel ToModel(this GetStudentSubjectSeminarList_Result item)
        {
            if (item == null) return null;
            return new StudentSubjectSeminarModel()
            {
                Id = item.Id,
                DepartmentId = item.DepartmentId,
                Title = item.Title,
                Details = item.Details,
                EventDate = item.EventDate,
                IsActive = item.IsActive,
                IsDeleted = item.IsDeleted,
                CreatedOn = item.CreatedOn,
                ModifiedOn = item.ModifiedOn,
                TotalRows = item.TotalRows,
                Department = item.Department
            };
        }

        public static StudentSubjectSeminarModel ToModel(this StudentSubjectSeminar item)
        {
            if (item == null) return null;
            return new StudentSubjectSeminarModel()
            {
                Id = item.Id,
                DepartmentId = item.DepartmentId,
                Title = item.Title,
                Details = item.Details,
                EventDate = item.EventDate,
                IsActive = item.IsActive,
                IsDeleted = item.IsDeleted,
                CreatedOn = item.CreatedOn,
                ModifiedOn = item.ModifiedOn
            };
        }
    }
}