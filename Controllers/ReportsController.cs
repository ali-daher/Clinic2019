using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Data;
using Clinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ReportsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = "RequireInsuranceRole")]
        public IActionResult GetReports()
        {

            if (_db.Reports.Count() != 0)
            {
                List<ReportModel> result = new List<ReportModel>();

                var findReports = _db.Reports.ToList();

                if (findReports == null) return NotFound();

                foreach (Report report in findReports)
                {
                    var findConsultation = _db.Consultations.FirstOrDefault(c => c.cons_id == report.report_cons_id);
                    var findPatient = _db.Patients.FirstOrDefault(p => p.pat_id == findConsultation.cons_pat_id);
                    var findDoctor = _db.Doctors.FirstOrDefault(d => d.dr_id == findConsultation.cons_dr_id);

                    if (findConsultation == null || findDoctor == null || findPatient == null)
                         return BadRequest(new JsonResult("can't get report's data")); 

                        ReportModel reportModel = new ReportModel();
                        reportModel.report_cons_id = report.report_cons_id;
                        reportModel.report_ins_name = report.report_ins_name;
                        reportModel.report_pat_id = findPatient.pat_id;
                        reportModel.report_dr_id = findDoctor.dr_id;
                        reportModel.report_cons_title = findConsultation.cons_title;
                        reportModel.report_cons_cost = findConsultation.cons_cost;
                        reportModel.rep_date = findConsultation.cons_date;

                        result.Add(reportModel);
                    
                }

                        return Ok(new JsonResult(result)); 
            }

            else
                return BadRequest(new JsonResult("can't get report's data"));
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Policy = "RequireInsuranceRole")]
        public IActionResult GetReportById([FromRoute]int id)
        {
            var findReport = _db.Reports.FirstOrDefault(r => r.report_id == id);
          
            if (findReport != null)
            {
                var findConsultation = _db.Consultations.FirstOrDefault(c => c.cons_id == findReport.report_cons_id);
                var findPatient = _db.Patients.FirstOrDefault(p => p.pat_id == findConsultation.cons_pat_id);
                var findDoctor = _db.Doctors.FirstOrDefault(d => d.dr_id == findConsultation.cons_dr_id);

                if (findConsultation == null || findDoctor == null || findPatient == null)
                    return BadRequest(new JsonResult("can't get report's data"));

                ReportModel report = new ReportModel();
                report.report_cons_id = findReport.report_cons_id;
                report.report_ins_name = findReport.report_ins_name;
                report.report_pat_id = findPatient.pat_id;
                report.report_dr_id = findDoctor.dr_id;
                report.report_cons_title = findConsultation.cons_title;
                report.report_cons_cost = findConsultation.cons_cost;
                report.rep_date = findConsultation.cons_date;

                return Ok(new JsonResult(report));
            }

            else
                return NotFound();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddReport(Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newRepModel = new ReportModel
            {
                rep_date = consultation.cons_date,
                report_cons_cost=consultation.cons_cost,
                report_cons_id=consultation.cons_id,
                report_cons_title=consultation.cons_title,
                report_dr_id=consultation.cons_dr_id,
                report_pat_id=consultation.cons_pat_id,
                report_ins_name=consultation.patient.pat_insurance_company_name
            };

            var newReport = new Report
            {
                report_ins_name=newRepModel.report_ins_name,
                report_cons_id=newRepModel.report_cons_id
            };

            var addReport = await _db.Reports.AddAsync(newReport);

            if (addReport != null)
            {
                await _db.SaveChangesAsync();

                return Ok(new JsonResult(newRepModel));
            }
            return BadRequest();
        }
    }
}
