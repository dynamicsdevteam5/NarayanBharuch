using NarayanBharuch.Areas.Admin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NarayanBharuch.Areas.Admin.Models.Repository
{
    public class DepartmentRepository : IDisposable
    {
        #region Get Role List
        public IEnumerable<Department> GetDepartmentList()
        {
            try
            {
                using (var _db = new NarayanBharuchEntities())
                {
                    return _db.Departments.ToList();
                }
            }
            catch (Exception ex)
            {
                LogFile.AddException("DepartmentRepository GetDepartmentList", ex.Message);
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