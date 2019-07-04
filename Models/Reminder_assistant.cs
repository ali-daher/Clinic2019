using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Reminder_assistant
    {
        [Required]
        [Key]
        public int reminder_id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime reminder_date { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Maximum length is {1}")]
        public String reminder_content { get; set; }

        [Required]
        public int reminder_priority { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public String reminder_title { get; set; }
    }
}
