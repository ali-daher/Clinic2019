using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Report
    {
        [Key]
        [Required]
        public int report_id { get; set; }

        [Required]
        public int report_cons_id { get; set; }

        [Required]
        [ForeignKey("report_cons_id")]
        public Consultation consultation;

        [Required]
        public string report_ins_name { get; set; }

        [Required]
        [ForeignKey("report_ins_id")]
        public Insurance_company insurance_Company;
    }
}
