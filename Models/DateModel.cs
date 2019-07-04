using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class DateModel
    {
        [Required]
        public int date_pat_id { get; set; }

        [Required]
        public int date_dr_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime date_dateTime { get; set; }
    }
}
