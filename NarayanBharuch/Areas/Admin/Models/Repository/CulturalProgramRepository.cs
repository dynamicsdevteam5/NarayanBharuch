using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NarayanBharuch.Areas.Admin.Models.AdminModel;
using NarayanBharuch.Areas.Admin.Helper;
using NarayanBharuch.Areas.Admin.Models.Extention;
namespace NarayanBharuch.Areas.Admin.Models.Repository
{
    public class CulturalProgramRepository : IDisposable
    {
        #region Get CulturalProgram List
        public IEnumerable<CulturalProgramModel> GetList(int? pageStart, int? pageSize, string searchfilter, string sortCol, string sortOrder)
        {
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    return _db.GetCulturalProgramList(searchfilter, pageStart, pageSize, 0, sortOrder).AsEnumerable().Select(p => p.ToModel()).ToList();
                }
            }
            catch (Exception e)
            {
                LogFile.AddException("CulturalProgramRepository GetCulturalProgramList", e.Message);
                return null;
            }
        }
        #endregion

        #region Add/Edit CulturalProgram
        public long Save(CulturalProgramModel model)
        {
            long id = 0;
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    var objTbl = _db.CulturalPrograms.Find(model.Id);
                    if (objTbl == null)
                    {
                        objTbl = new CulturalProgram();
                        objTbl.CreatedOn = DateTime.Now;
                        _db.CulturalPrograms.Add(objTbl);
                    }
                    else
                    {
                        _db.Entry(objTbl).State = EntityState.Modified;
                        objTbl.ModifiedOn = DateTime.Now;
                    }
                    objTbl.Title = model.Title.Trim();
                    objTbl.Details = model.Details;
                    objTbl.DepartmentId = model.DepartmentId;
                    objTbl.EventDate = model.EventDate;
                    objTbl.IsActive = true;
                    objTbl.IsDeleted = false;
                    _db.SaveChanges();
                    return objTbl.Id;
                }
            }
            catch (Exception e)
            {
                LogFile.AddException("CulturalProgramRepository SaveCulturalProgram", e.Message);
                return id;
            }
        }        
        #endregion

        #region Activate/Deactive CulturalProgram
        public string SetActiveDeactive(int id)
        {
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    var objTbl = _db.CulturalPrograms.Find(id);
                    var isActiveMsg = (objTbl.IsActive ? "deactivated" : "activated");
                    if (objTbl.IsActive)
                    {
                        objTbl.IsActive = false;
                    }
                    else
                    {
                        objTbl.IsActive = true;
                    }
                    _db.Entry(objTbl).CurrentValues.SetValues(objTbl);
                    _db.SaveChanges();
                    return isActiveMsg;
                }
            }
            catch (Exception e)
            {
                LogFile.AddException("CulturalProgramRepository SetActiveDeactive", e.Message);
                return "";
            }
        }
        #endregion

        #region Delete experiment
        public bool Delete(int id)
        {
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    var objTbl = _db.CulturalPrograms.Find(id);
                    if (objTbl != null)
                    {
                        objTbl.ModifiedOn = DateTime.Now;
                        objTbl.IsDeleted = true;
                        _db.Entry(objTbl).CurrentValues.SetValues(objTbl);
                        _db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                LogFile.AddException("CulturalProgramRepository DeleteCulturalProgram", e.Message);
                return false;
            }
        }
        #endregion

        #region Get CulturalProgramData By Id
        public CulturalProgramModel GetById(int id)
        {
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    return _db.CulturalPrograms.AsEnumerable().Select(p => p.ToModel()).FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                LogFile.AddException("CulturalProgramRepository GetCulturalProgramDataById", e.Message);
                return null;
            }
        }
        #endregion

        #region Dispose
        private bool _disposed;
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    using (var db = new NarayanBharuchEntities())
                    {
                        db.Dispose();
                    }
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}