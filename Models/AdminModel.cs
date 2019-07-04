using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class AdminModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public String admin_username { get; set; }

        [StringLength(4000, ErrorMessage = "Maximum length is {1}")]
        [DataType(DataType.Password)]
        public String admin_password { get; set; }

        [Required]
        [StringLength(4000, ErrorMessage = "Maximum length is {1}")]
        [DataType(DataType.PhoneNumber)]
        public String admin_phone { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "Maximum length is {1}")]
        [DataType(DataType.EmailAddress)]
        public String admin_email { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String admin_fname { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String admin_mname { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String admin_lname { get; set; }
    }
}
