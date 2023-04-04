using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentGrievance.Models
{
    public class Authority
    {
        [Required(ErrorMessage = "Please enter your loginId")]
        public string LoginId { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public int DeptId { get; set; }
        public bool HasFlaggingAuthority { get; set; }
    }
}