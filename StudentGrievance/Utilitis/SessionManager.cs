using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentGrievance.Utilitis
{
    public class SessionManager
    {
        public void RemoveSession()
        {
            try
            {
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Session.RemoveAll();
            }
            catch
            { }
        }

        public Int64 UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                }
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
        
        public Int64 RollId
        {
            get
            {
                if (HttpContext.Current.Session["RollId"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Session["RollId"]);
                }
            }
            set
            {
                HttpContext.Current.Session["RollId"] = value;
            }
        }
        
        public Int32 DeptId
        {
            get
            {
                if (HttpContext.Current.Session["DeptId"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Session["DeptId"]);
                }
            }
            set
            {
                HttpContext.Current.Session["DeptId"] = value;
            }
        }

        public string Name
        {
            get
            {
                if (HttpContext.Current.Session["Name"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["Name"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["Name"] = value;
            }
        }

        public string MobileNo
        {
            get
            {
                if (HttpContext.Current.Session["MobileNo"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session["MobileNo"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["MobileNo"] = value;
            }
        }

        public string UserExceptionSession
        {
            get
            {
                if (HttpContext.Current.Session["UserExceptionSession"] != null)
                {
                    return Convert.ToString((HttpContext.Current.Session["UserExceptionSession"]));
                }
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["UserExceptionSession"] = value;
            }
        }

        public string Loginid
        {
            get
            {
                if (HttpContext.Current.Session["Loginid"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["Loginid"]);
                }
            }
            set
            {
                HttpContext.Current.Session["Loginid"] = value;
            }
        }

    }
}