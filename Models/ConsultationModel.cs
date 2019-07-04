using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class ConsultationModel
    {
        [Required]
        public int cons_pat_id { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public String cons_title { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public String cons_type { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime cons_date { get; set; }

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
    }
}
