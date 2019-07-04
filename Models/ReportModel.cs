using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class ReportModel
    {
        public int report_id { get; set; }

        [Required]
        public int report_cons_id { get; set; }

        public int report_dr_id { get; set; }

        public int report_pat_id { get; set; }

        public string report_cons_title { get; set; }

        public int report_cons_cost { get; set; }

        public DateTime rep_date { get; set; }

        [Required]
        public string report_ins_name { get; set; }

    }
}
