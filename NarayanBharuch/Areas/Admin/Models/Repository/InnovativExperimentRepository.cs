using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NarayanBharuch.Areas.Admin.Models.AdminModel;
using NarayanBharuch.Areas.Admin.Helper;
using NarayanBharuch.Areas.Admin.Models.Extention;

namespace NarayanBharuch.Areas.Admin.Models.Repository
{
    public class InnovativExperimentRepository : IDisposable
    {
        #region Get InnovativExperiment List
        public IEnumerable<InnovativExperimentModel> GetList(int? pageStart, int? pageSize, string searchfilter, string sortCol, string sortOrder)
        {
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    return _db.GetInnovativExperimentList(searchfilter, pageStart, pageSize, 0, sortOrder).AsEnumerable().Select(p => p.ToModel()).ToList();
                }
            }
            catch (Exception e)
            {
                LogFile.AddException("InnovativExperimentRepository GetInnovativExperimentList", e.Message);
                return null;
            }
        }
        #endregion

        #region Add/Edit InnovativExperiment
        public long Save(InnovativExperimentModel model)
        {
            long id = 0;
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    var experimentTbl = _db.InnovativExperiments.Find(model.Id);                    
                    if (experimentTbl == null)
                    {
                        experimentTbl = new InnovativExperiment();
                        experimentTbl.CreatedOn = DateTime.Now;
                        _db.InnovativExperiments.Add(experimentTbl);
                    }
                    else
                    {
                        _db.Entry(experimentTbl).State = EntityState.Modified;
                        experimentTbl.ModifiedOn = DateTime.Now;                        
                    }
                    experimentTbl.Title = model.Title.Trim();
                    experimentTbl.Details = model.Details;
                    experimentTbl.DepartmentId = model.DepartmentId;
                    experimentTbl.EventDate = model.EventDate;
                    experimentTbl.IsActive = true;
                    experimentTbl.IsDeleted = false;
                    _db.SaveChanges();
                    return experimentTbl.Id;
                }
            }
            catch (Exception e)
            {
                LogFile.AddException("InnovativExperimentRepository SaveInnovativExperiment", e.Message);
                return id;
            }
        }

        #endregion

        #region Activate/Deactive InnovativExperiment
        public string SetActiveDeactive(int id)
        {
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    var data = _db.InnovativExperiments.Find(id);
                    var isActiveMsg = (data.IsActive ? "deactivated" : "activated");
                    if (data.IsActive)
                    {
                        data.IsActive = false;
                    }
                    else
                    {
                        data.IsActive = true;
                    }
                    _db.Entry(data).CurrentValues.SetValues(data);
                    _db.SaveChanges();
                    return isActiveMsg;
                }
            }
            catch (Exception e)
            {
                LogFile.AddException("InnovativExperimentRepository SetActiveDeactive", e.Message);
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
                    var experimentData = _db.InnovativExperiments.Find(id);
                    if (experimentData != null)
                    {
                        experimentData.ModifiedOn = DateTime.Now;
                        experimentData.IsDeleted = true;
                        _db.Entry(experimentData).CurrentValues.SetValues(experimentData);
                        _db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                LogFile.AddException("InnovativExperimentRepository DeleteInnovativExperiment", e.Message);
                return false;
            }
        }
        #endregion

        #region Get InnovativExperimentData By Id
        public InnovativExperimentModel GetById(int id)
        {
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    return _db.InnovativExperiments.AsEnumerable().Select(p => p.ToModel()).FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                LogFile.AddException("InnovativExperimentRepository GetInnovativExperimentDataById", e.Message);
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