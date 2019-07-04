using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Date
    {
        [Key]
        [Required]
        public int date_id { get; set; }

        [Required]
        public int date_pat_id { get; set; }

        [Required]
        [ForeignKey("date_pat_id")]
        public Patient patient { get; set; }

        [Required]
        public int date_dr_id { get; set; }

        [Required]
        [ForeignKey("date_dr_id")]
        public Doctor doctor { get; set; }

        [DataType(DataType.Date)]
        public DateTime date_dateTime { get; set; }
    }
}
