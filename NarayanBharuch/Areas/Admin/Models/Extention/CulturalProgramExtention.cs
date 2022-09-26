using NarayanBharuch.Areas.Admin.Models.AdminModel;
namespace NarayanBharuch.Areas.Admin.Models.Extention
{
    public static class CulturalProgramExtention
    {
        public static CulturalProgramModel ToModel(this GetCulturalProgramList_Result item)
        {
            if (item == null) return null;
            return new CulturalProgramModel()
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
        
        public static CulturalProgramModel ToModel(this CulturalProgram item)
        {
            if (item == null) return null;
            return new CulturalProgramModel()
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