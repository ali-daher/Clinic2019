using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Data;
using Clinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    public class ConsultationsController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly UserManager<IdentityUser> _userManager;
        public ConsultationsController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = "RequireDoctorRole")]
        public IActionResult GetConsultations()
        {
            if (_db.Consultations.Count() != 0)
                return Ok(_db.Consultations.ToList());
            else
                return BadRequest(new JsonResult("No Consultations to show"));
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Policy = "RequireDoctorRole")]
        public IActionResult GetConsultationById([FromRoute]int id)
        {
            var findConsultation = _db.Consultations.FirstOrDefault(c => c.cons_id == id);

            if (findConsultation != null)
            {
                ConsultationModel consultation = new ConsultationModel();
                consultation.cons_title = findConsultation.cons_title;
                consultation.cons_date = findConsultation.cons_date;
                consultation.cons_type = findConsultation.cons_type;
                consultation.cons_symptoms = findConsultation.cons_symptoms;
                consultation.cons_diagnosis = findConsultation.cons_diagnosis;
                consultation.cons_temp = findConsultation.cons_temp;
                consultation.cons_blood_pressure = findConsultation.cons_blood_pressure;
                consultation.cons_cost = findConsultation.cons_cost;
                consultation.cons_treatment = findConsultation.cons_treatment;
                consultation.cons_insurance_confirmation = findConsultation.cons_insurance_confirmation;

                return Ok(new JsonResult(consultation));
            }

            else
                return NotFound();
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireDoctorRole")]
        public async Task<IActionResult> AddConsultation([FromBody] ConsultationModel consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string id = _userManager.GetUserId(HttpContext.User);

            var findDoctor = _db.Doctors.FirstOrDefault(d => d.dr_user_id == id);

            var newConsultation = new Consultation
            {
                cons_title = consultation.cons_title,
                cons_date = consultation.cons_date,
                cons_type = consultation.cons_type,
                cons_symptoms = consultation.cons_symptoms,
                cons_blood_pressure = consultation.cons_blood_pressure,
                cons_cost = consultation.cons_cost,
                cons_pat_id = consultation.cons_pat_id,
                cons_temp = consultation.cons_temp,
                cons_diagnosis = consultation.cons_diagnosis,
                cons_treatment = consultation.cons_treatment,
                cons_insurance_confirmation = consultation.cons_insurance_confirmation,
                cons_dr_id = findDoctor.dr_id
            };

            var addConsultation = await _db.Consultations.AddAsync(newConsultation);

            if (addConsultation != null) {
                var addReport = new ReportsController(_db).AddReport(newConsultation);
                await _db.SaveChangesAsync();

            return Ok(new { ConsultationId = newConsultation.cons_id, Doctorid = newConsultation.cons_dr_id, Patientid = newConsultation.cons_pat_id, status = 1, message = "Registration of consultation Succeded on " + newConsultation.cons_date });
            }
            return BadRequest(new JsonResult("Can't add this consultation"));
        }

        [HttpPut("[action]/{id}")]
        [Authorize(Policy = "RequireDoctorRole")]
        public async Task<IActionResult> UpdateConsultation([FromRoute] int id, [FromBody] ConsultationModel consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var findConsultation = _db.Consultations.FirstOrDefault(d => d.cons_id == id);

            var findReport = _db.Reports.FirstOrDefault(r => r.report_cons_id == id);

            if (findConsultation == null)
            {
                return NotFound();
            }

            // If the consultation was found
            findConsultation.cons_title = consultation.cons_title;
            findConsultation.cons_date = consultation.cons_date;
            findConsultation.cons_type = consultation.cons_type;
            findConsultation.cons_symptoms = consultation.cons_symptoms;
            findConsultation.cons_blood_pressure = consultation.cons_blood_pressure;
            findConsultation.cons_cost = consultation.cons_cost;
            findConsultation.cons_temp = consultation.cons_temp;
            findConsultation.cons_diagnosis = consultation.cons_diagnosis;
            findConsultation.cons_treatment = consultation.cons_treatment;
            findConsultation.cons_insurance_confirmation = consultation.cons_insurance_confirmation;

            _db.Entry(findConsultation).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return Ok(new JsonResult("The Consultation with id " + id + " is updated"));

        }

        [HttpDelete("[action]/{id}")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> DeleteConsultation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //find consultation
            var findConsultation = _db.Consultations.FirstOrDefault(c => c.cons_id == id);

            if (findConsultation != null)
            {
                _db.Consultations.Remove(findConsultation);

                await _db.SaveChangesAsync();

                return Ok(new JsonResult("The Consultation with id " + findConsultation.cons_id + " is Deleted"));
            }

            return BadRequest(new JsonResult("Can't delete this Consultation"));
        }
    }
}
