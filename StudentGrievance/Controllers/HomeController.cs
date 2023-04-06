using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using PracticalEvaluation.DbRepository;
using StudentGrievance.DbRepository;
using StudentGrievance.Models;
using StudentGrievance.Utilitis;

namespace StudentGrievance.Controllers
{
    public class HomeController : Controller
    {
        CommonFileUpload com = new CommonFileUpload();
        AccountDb adb = new AccountDb();
        AdminDB admindb = new AdminDB();
        SessionManager sm = new SessionManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StudentGrievance()
        {
            Student model = new Student();
            if (!String.IsNullOrEmpty(Convert.ToString(TempData["msg"])) && !String.IsNullOrEmpty(Convert.ToString(TempData["flag"])))
            {

            }
            else
            {
                TempData["msg"] = "";
                TempData["flag"] = 0;
            }
            return View(model);
        }

        public ActionResult SendGrievanceOtp(Student model)
        {
            Student obj = new Student();
            obj = adb.CheckUserValidation<Student>(model);
            if (obj.flag == 1)
            {
                Random rnd = new Random();
                string otp = (rnd.Next(100000, 999999)).ToString();
                string message = SMS.OTPMemberMessage2(model.Name, otp, "OTP");
                //string status = SMS.SendSMS(model.mobile, message, ConfigurationManager.AppSettings["TEMP-Examotp"].ToString());
                //var res = acdb.InsertOTP(otp, message, status, 0, mobile);
                sendEmail(model.Email, model.Name, otp);
                Session["Name"] = model.Name;
                Session["Email"] = model.Email;
                Session["mobile"] = model.mobile;
                TempData["otp"] = otp;
                return RedirectToAction("StudentGrivanceOtpVerify");
            }
            else
            {
                TempData["msg"] = obj.msg;
                TempData["flag"] = obj.flag;
                return RedirectToAction("StudentGrievance");
            }
        }

        public ActionResult StudentGrivanceOtpVerify()
        {
            Student model = new Student();
            model.Name = Convert.ToString(Session["Name"]);
            model.Email = Convert.ToString(Session["Email"]);
            model.mobile = Convert.ToString(Session["mobile"]);

            return View(model);
        }

        [HttpGet]
        public ActionResult Studentcomplain()
        {
            StudentGrievanceComplaint model = new StudentGrievanceComplaint();
            model.ApplicantName = Convert.ToString(Session["Name"]);
            model.Email = Convert.ToString(Session["Email"]);
            model.mobile = Convert.ToString(Session["mobile"]);
            ViewBag.GrivanceCategory = adb.GetGrievanceCategory();
            ViewBag.Department = adb.GetDepartmentCategory();
            return View(model);
        }

        public JsonResult StudentGrivanceUploadFile(HttpPostedFileBase File)
        {
            string Dirpath = "~/Content/writereaddata/StudentGrivanceUploadFile/";
            string path = "";
            string filename = File.FileName;
            bool res = false;
            string msg = "";
            if (!Directory.Exists(Server.MapPath(Dirpath)))
            {
                Directory.CreateDirectory(Server.MapPath(Dirpath));
            }
            string ext = Path.GetExtension(File.FileName);
            var status = com.ValidateImagePDF_FileExtWithSize(File, 2048);
            if (status == "Valid")
            {

                filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + filename;
                string completepath = Path.Combine(Server.MapPath(Dirpath), filename);
                if (System.IO.File.Exists(completepath))
                {
                    System.IO.File.Delete(completepath);
                }

                File.SaveAs(completepath);
                path = Dirpath + filename;
                res = true;
            }
            else
            {
                msg = status;
            }
            return Json(new { result = res, fpath = path, mesg = msg });



        }

        public void sendEmail(string email, string Name, string otp)
        {
            string MessageBody = getMessageBody(Name, otp);
            string subject = "Student Grievance Portal";
            GrievanceMail.SendEmailMessag(email, subject, MessageBody);
            //return Json(otp, JsonRequestBehavior.AllowGet);
        }

        public String getMessageBody(string Name, string otp)
        {
            StreamReader rd = new StreamReader(HostingEnvironment.MapPath(@"~/EmailTemplates/EmailRemplates.html"));
            string msgBody = rd.ReadToEnd();
            msgBody = msgBody.Replace("[User]", Name);
            msgBody = msgBody.Replace("[otp]", otp);
            return msgBody;
        }

        public JsonResult SendOtp(string mobile, string Name, string Email = "")
        {
            Random rnd = new Random();
            string otp = (rnd.Next(100000, 999999)).ToString();
            string message = SMS.OTPMemberMessage2(Name, otp, "OTP");
            string status = SMS.SendSMS(mobile, message, ConfigurationManager.AppSettings["TEMP-Examotp"].ToString());
            //var res = acdb.InsertOTP(otp, message, status, 0, mobile);
            TempData["otp"] = otp;
            if (!String.IsNullOrEmpty(Email))
            {
                sendEmail(Email, Name, otp);
            }
            if (status == "OK")
                return Json(otp, JsonRequestBehavior.AllowGet);
            else
                return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Studentcomplain(StudentGrievanceComplaint model)
        {
            model.ApplicantName = Convert.ToString(Session["Name"]);
            model.Email = Convert.ToString(Session["Email"]);
            model.mobile = Convert.ToString(Session["mobile"]);
            model.Ip = CommonFileUpload.GetIPAddress();
            model = adb.InsertStudentGrivance<StudentGrievanceComplaint>(model);
            ViewBag.GrivanceCategory = adb.GetGrievanceCategory();
            ViewBag.Department = adb.GetDepartmentCategory();
            TempData["msg"] = model.msg;
            TempData["flag"] = model.flag;
            return RedirectToAction("StudentGrievance");
        }

        [HttpGet]
        public ActionResult ComplainetStatus()
        {
            ComplainedStatus model = new ComplainedStatus();
            ViewBag.GrivanceCategory = adb.GetGrievanceCategory();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult ComplainetStatus(ComplainedStatus model)
        {
            model = adb.GetComplainetStatus<ComplainedStatus>(model);
            ViewBag.GrivanceCategory = adb.GetGrievanceCategory();
            return View(model);
        }

        [HttpGet]
        public ActionResult AuthorityLogin()
        {
            Authority model = new Authority();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult AuthorityLogin(Authority model)
        {
            model = admindb.ValidateUserLogin<Authority>(model);
            if (model.ResponseCode == 0 && model.ResponseMessage == "Success")
            {
                sm.UserId = model.Id;
                sm.Name = model.Name;
                sm.DeptId = model.DeptId;
                sm.Loginid = model.LoginId;
                sm.RollId = model.RoleId;

                return RedirectToAction("Index", "Admin");
            }
            else
            { 
            
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("index","Home");
        }

    }
}