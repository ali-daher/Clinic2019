using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Assistant
    {
        [Required]
        [Key]
        public int as_id { get; set; }

        [Required]
        public string as_user_id { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String as_fname { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String as_mname { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public String as_lname { get; set; }

        [Required]
        public int as_dr_id { get; set; }

        [Required]
        [ForeignKey("as_dr_id")]
        public Doctor doctor { get; set; }
    }

}
