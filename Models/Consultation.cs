using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Consultation
    {
        [Key]
        [Required]
        public int cons_id { get; set; }

        [Required]
        public int cons_pat_id { get; set; }

        [Required]
        [ForeignKey("cons_pat_id")]
        public Patient patient { get; set; }

        [Required]
        public int cons_dr_id { get; set; }

        [Required]
        [ForeignKey("cons_dr_id")]
        public Doctor doctor { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public String cons_title { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public String cons_type { get; set; }

        [DataType(DataType.Date)]
        public DateTime cons_date { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Maximum length is {1}")]
        public String cons_symptoms { get; set; }

        [StringLength(500, ErrorMessage = "Maximum length is {1}")]
        public String cons_diagnosis { get; set; }

        [StringLength(5, ErrorMessage = "Maximum length is {1}")]
        public String cons_temp { get; set; }

        [StringLength(5, ErrorMessage = "Maximum length is {1}")]
        public String cons_blood_pressure { get; set; }

        [Required]
        public int cons_cost { get; set; }

        [StringLength(500, ErrorMessage = "Maximum length is {1}")]
        public string cons_treatment { get; set; }

        [Required]
        public bool cons_insurance_confirmation { get; set; }

        public List<Report> reports { get; set; }
    }
}
