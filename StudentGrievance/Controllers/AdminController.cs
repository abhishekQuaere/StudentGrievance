using StudentGrievance.DbRepository;
using StudentGrievance.Models;
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

        public ActionResult Index()
        {
            Admin model = new Admin();
            model.lst = adminDB.GetAllGrivance<Admin>();
            return View();
        }
    }
}