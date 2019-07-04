using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class Message
    {
        [Required]
        [Key]
        public int m_id { get; set; }

        [Required]
        public string m_sender_id { get; set; }

        [Required]
        public string m_subject { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Maximum length is {1}")]
        public string m_message { get; set; }

        [Required]
        public DateTime m_date { get; set; }
    }
}
