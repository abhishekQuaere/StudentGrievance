using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentGrievance.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please enter your Mobile Number")]
        [RegularExpression(@"^[5-9][0-9]{9}$", ErrorMessage = "Please enter correct Mobile No.")]
        [MaxLength(10)]
        public string mobile { get; set; }

        [Required(ErrorMessage = "Please enter your Email Id")]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please enter valid Email ID.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Valid OTP")]
        public string OTP { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        public string msg { get; set; }

        public int flag { get; set; }

    }

    public class StudentGrievanceComplaint
    {
        [Required(ErrorMessage = "Please enter your Mobile Number")]
        [RegularExpression(@"^[5-9][0-9]{9}$", ErrorMessage = "Please enter correct Mobile No.")]
        [MaxLength(10)]
        public string mobile { get; set; }

        [Required(ErrorMessage = "Please enter your Email Id")]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please enter valid Email ID.")]
        public string Email { get; set; }

        public string UserType { get; set; }
        public string InstituteCode { get; set; }
        public string ApplicantName { get; set; }
        public string GrievanceCategory { get; set; }
        public string File { get; set; }
        public string GrievanceDetails { get; set; }
        public string Ip { get; set; }
        public string msg { get; set; }
        public int flag { get; set; }

    }

    public class ComplainedStatus
    {
        [Required(ErrorMessage = "Please enter your Complainet Number")]
        public string ComplainetNo { get; set; }

        [Required(ErrorMessage = "Please enter your Mobile Number")]
        [RegularExpression(@"^[5-9][0-9]{9}$", ErrorMessage = "Please enter correct Mobile No.")]
        [MaxLength(10)]
        public string mobile { get; set; }

        [Required(ErrorMessage = "Please enter your Email Id")]
        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please enter valid Email ID.")]
        public string Email { get; set; }
        public int GrivanceId { get; set; }
        public string ApplicantName { get; set; }
        public string UserType { get; set; }
        public string InstituteCode { get; set; }
        public string GrievanceCategory { get; set; }
        public string UploadFile { get; set; }
        public string GrievanceDetails { get; set; }
        public string Reply { get; set; }
        public string ReferenceNumber { get; set; }
        public string CreatedDate { get; set; }
        public string ReplyDate { get; set; }
        public int flag { get; set; }

    }
}