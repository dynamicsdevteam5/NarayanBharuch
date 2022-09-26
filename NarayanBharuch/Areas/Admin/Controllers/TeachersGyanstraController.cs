using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NarayanBharuch.Areas.Admin.Models.AdminModel;
using NarayanBharuch.Areas.Admin.Models.Repository;
namespace NarayanBharuch.Areas.Admin.Controllers
{
    public class TeachersGyanstraController : SessionController
    {
        private readonly TeachersGyanstraRepository _repo = new TeachersGyanstraRepository();
        // GET: Admin/TeachersGyanstra
        public ActionResult Index(int? id)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserId"])))
            {
                ViewBag.Photos = new List<string>();
                List<Models.Department> departments = new List<Models.Department>();
                ViewBag.DepartmentData = departments;
                using (DepartmentRepository _deptRepo = new DepartmentRepository())
                {
                    departments = _deptRepo.GetDepartmentList().ToList();
                    ViewBag.DepartmentData = new SelectList(departments, "Id", "Name");
                }
                if (string.IsNullOrEmpty(id.ToString()))
                    ViewBag.FormType = "";
                else
                {
                    ViewBag.FormType = "Edit";
                    var data = _repo.GetById(Convert.ToInt32(id));
                    if (data != null)
                    {
                        ViewBag.DepartmentData = new SelectList(departments, "Id", "Name", data.DepartmentId);
                        var photos = Helper.FileHelper.GetFilesFromFolder("TeachersGyanstra", Convert.ToInt32(id));
                        if (photos.Count > 0)
                        {
                            data.Photos = string.Join(",", photos);
                            ViewBag.Photos = photos;
                        }
                    }
                    return PartialView("P_Main", data);
                }
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        #region TeachersGyanstra Post Data
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Index(TeachersGyanstraModel model)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserId"])))
            {
                long id = _repo.Save(model);
                if (id > 0)
                {
                    ViewBag.SuccessMessage = "TeachersGyanstra saved successfully. :)";
                    Helper.FileHelper.SaveToMainFolder("TeachersGyanstra", model.Photos, id);
                }
                else
                {
                    ViewBag.ErrorMessage = "Please try again :(";
                }
                ViewBag.FormType = "";
            }
            return PartialView("P_List");
        }
        #endregion

        #region Delete TeachersGyanstra
        public ActionResult Delete(int? id)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserId"])))
            {
                var flag = _repo.Delete(Convert.ToInt32(id));
                if (flag == false)
                    ViewBag.ErrorMessage = "Please try again :(";
                else
                    ViewBag.SuccessMessage = "Record deleted successfully. :)";
                ViewBag.FormType = "";
            }
            return PartialView("P_List");
        }
        #endregion

        #region SetActiveDeactive
        public ActionResult SetActiveDeactive(int? id)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["UserId"])))
                ViewBag.SuccessMessage = _repo.SetActiveDeactive(Convert.ToInt32(id));
            return PartialView("P_List");
        }
        #endregion

        #region Custome Paging
        public JsonResult FnPaging()
        {
            var searchpara = Request.Params["sSearch"];
            var sortablecol = Request.Params["iSortCol_0"];
            var sortorder = Request.Params["sSortDir_0"];
            var iDisplayStartstr = Request.Params["iDisplayStart"];
            int iDisplayStart = Convert.ToInt16(iDisplayStartstr);
            var iDisplayLengthstr = Request.Params["iDisplayLength"];
            int iDisplayLength = Convert.ToInt16(iDisplayLengthstr);
            var model = _repo.GetList(iDisplayStart, iDisplayLength, searchpara, sortablecol, sortorder).ToList();
            var data = model.ToList();
            var count = "0";
            var strarr = new string[data.Count][];
            for (var i = 0; i < data.Count; i++)
            {
                count = data[i].TotalRows.ToString();
                var subaray = new string[5];
                subaray[0] = data[i].Title;
                subaray[1] = data[i].Department;
                subaray[2] = data[i].EventDate.ToShortDateString();
                if (data[i].IsActive)
                    subaray[3] = "<a href='javascript:void(0);' onclick=SetActiveDeactive('" + data[i].Id +
                                 "','Y') class='btn ink-reaction btn-raised btn-sm btn-success'>Yes</a>";
                else
                    subaray[3] = "<a href='javascript:void(0);' onclick=SetActiveDeactive('" + data[i].Id +
                                 "','N') class='btn ink-reaction btn-raised btn-sm btn-danger'>No</a>";
                subaray[4] = "";
                subaray[4] += "<a class='btn ink-reaction btn-floating-action btn-sm btn-primary fa fa-edit' data-ajax-complete='showEdit();scrolltop();' data-ajax='true' data-ajax-method='GET' data-ajax-mode='replace' data-ajax-update='#P_Main' href='/Admin/TeachersGyanstra/Index?id=" + data[i].Id + "' title='Edit'></a>";
                subaray[4] += "   <a href='javascript:void(0);' class='btn ink-reaction btn-floating-action btn-sm btn-danger fa fa-trash' title='Delete' onclick=Delete('" + data[i].Id + "')></a>";
                strarr[i] = subaray;
            }
            return Json(new { sEcho = Request.Params["sEcho"], recordsTotal = count, recordsFiltered = count, iTotalRecords = count, iTotalDisplayRecords = count, aaData = strarr }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region FileUpload
        /// <summary>
        /// Save file to Temp folder.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveToTemp()
        {
            string imagefiles = "";
            try
            {                
                string path = Server.MapPath("~/Photos/TeachersGyanstra/Temp/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    file.SaveAs(path + file.FileName);
                    imagefiles += "/Photos/TeachersGyanstra/Temp/" + file.FileName + ",";
                }
                imagefiles = imagefiles.TrimEnd(',');
                return Json(imagefiles, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(imagefiles, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Make Temp folder empty once all files are copied to destination folder.
        /// </summary>
        public void DeleteFile(string photo)
        {
            string sourcePath = Server.MapPath("~" + photo);
            if (System.IO.File.Exists(sourcePath))
            {
                try
                {
                    System.IO.File.Delete(sourcePath);
                }
                catch {}
            }
        }
        #endregion
    }
}