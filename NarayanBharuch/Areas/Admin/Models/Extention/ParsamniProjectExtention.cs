using NarayanBharuch.Areas.Admin.Models.AdminModel;
namespace NarayanBharuch.Areas.Admin.Models.Extention
{
    public static class ParsamniProjectExtention
    {
        public static ParsamniProjectModel ToModel(this GetParsamniProjectList_Result item)
        {
            if (item == null) return null;
            return new ParsamniProjectModel()
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

        public static ParsamniProjectModel ToModel(this ParsamniProject item)
        {
            if (item == null) return null;
            return new ParsamniProjectModel()
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