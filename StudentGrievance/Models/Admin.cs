using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentGrievance.Models
{
    public class Admin
    {
        public int GrivanceId { get; set; }
        public string ApplicantName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UploadFile { get; set; }
        public string GrievanceCategory { get; set; }
        public string GrievanceDetails { get; set; }
        public string InstituteCode { get; set; }
        public string Reply { get; set; }
        public string UserType { get; set; }
        public List<Admin> lst { get; set; }
    }
}