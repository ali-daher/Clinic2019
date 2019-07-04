using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Doctor
    {
        [Required]
        [Key]
        public int dr_id { get; set; }

        [Required]
        public string dr_user_id { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String dr_fname { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String dr_mname { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String dr_lname { get; set; }

        [StringLength(10, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String dr_gender { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public String dr_speciality { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public String dr_address { get; set; }

        [StringLength(400, ErrorMessage = "Maximum length is {1}")]
        public String dr_about { get; set; }

        public List<Assistant> Assistants { get; set; }

        public List<Consultation> consultations { get; set; }

        public List<Date> dates { get; set; }
    }
}
