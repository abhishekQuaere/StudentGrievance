using StudentGrievance.DbRepository;
using StudentGrievance.Models;
using StudentGrievance.Utilitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentGrievance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminDB adminDB = new AdminDB();
        SessionManager sm = new SessionManager();

        public ActionResult Index()
        {
            Admin model = new Admin();
            model.lst = adminDB.GetAllGrivance<Admin>(sm.DeptId);
            return View(model);
        }

        [HttpPost]
        public JsonResult ReplyGreivance(string greivanceId, string Reply)
        {
            int ReplyBy = Convert.ToInt32(sm.UserId);
            var res = adminDB.ReplyGreivance<int>(Convert.ToInt32(greivanceId),Reply,ReplyBy);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

    }
}